using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Question;
using TrivialPursuitMVC.Data;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuit.Services
{
    public class QuestionService
    {
        private CategoryService _categoryService = new CategoryService();
        private UserService _userService = new UserService();
        private VersionService _versionService = new VersionService();
        private readonly Guid _userId;
        public QuestionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuestion(QuestionCreate model)
        {
            var entity =
                new Question()
                {
                    AuthorId = _userId.ToString(),
                    Text = model.Text,
                    CategoryId = _categoryService.GetCategoryIdByName(model.Category),
                    VersionId = _versionService.GetVersionIdByName(model.Version),
                    IsUserGenerated = _userService.ConfirmUserIsPlayer(_userId.ToString())
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Questions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuestionListItem> GetQuestions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Questions
                        .Select(
                            e =>
                                new QuestionListItem
                                {
                                    QuestionId = e.Id,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }
        //add another version of this and and if statement in the controller that accesses one or the other depending on the type of user (admin vs player)
        public QuestionDetail GetQuestionById(int id)
        {
            var asvc = new AnswerService();
            using (var ctx = new ApplicationDbContext())
            {
                if (_userService.ConfirmUserIsPlayer(_userId.ToString()))
                {
                    var playerEntity =
                         ctx
                             .Questions
                             .Single(e => e.Id == id && e.AuthorId == _userId.ToString());
                    return
                        new QuestionDetail
                        {
                            Id = playerEntity.Id,
                            Text = playerEntity.Text,
                            Category = playerEntity.Category.Name,
                            Version = playerEntity.Version.Name,
                            Author = playerEntity.Author.DisplayName,
                            Answers = asvc.ConvertAnswersToStrings(playerEntity.Answers)
                        };
                }
                var adminEntity =
                    ctx
                        .Questions
                        .Single(e => e.Id == id);
                return
                    new QuestionDetail
                    {
                        Id = adminEntity.Id,
                        Text = adminEntity.Text,
                        Category = adminEntity.Category.Name,
                        Version = adminEntity.Version.Name,
                        Author = adminEntity.Author.DisplayName,
                        Answers = asvc.ConvertAnswersToStrings(adminEntity.Answers)
                    };
            }
        }
        public bool UpdateQuestion(QuestionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.Id == model.Id && e.AuthorId == _userId.ToString());

                entity.Text = model.Text;
                entity.CategoryId = _categoryService.GetCategoryIdByName(model.Category);
                entity.VersionId = _versionService.GetVersionIdByName(model.Version);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteQuestion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (_userService.ConfirmUserIsPlayer(_userId.ToString()))
                {//add logic for if the user doesn't have authorization to delete someone else's note
                    var userEntity =
                    ctx
                        .Questions
                        .Single(e => e.Id == id && e.AuthorId == _userId.ToString());

                    ctx.Questions.Remove(userEntity);
                    return ctx.SaveChanges() == 1;
                }
                var adminEntity = ctx.Questions.Single(e => e.Id == id && e.AuthorId == _userId.ToString());

                ctx.Questions.Remove(adminEntity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
