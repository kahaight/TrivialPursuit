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
                var entity =
                    ctx
                        .Questions
                        .Single(e => e.Id == id && e.AuthorId == _userId.ToString());//doesn't work if you aren't the author
                return
                    new QuestionDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Category = entity.Category.Name,
                        Version = entity.Version.Name,
                        Author = entity.Author.DisplayName,
                        Answers = asvc.ConvertAnswersToStrings(entity.Answers)
                    };
            }
        }
    }
}
