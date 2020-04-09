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
        private readonly UserService _userService = new UserService();
        private readonly Guid _userId;
        public QuestionService() { }
        public QuestionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuestion(QuestionCreate model)
        {
            var csvc = GetCategoryService();
            var vsvc = GetVersionService();
            var entity =
                new Data.DataClasses.Question()
                {
                    AuthorId = _userId.ToString(),
                    Text = model.Text,
                    CategoryId = csvc.GetCategoryIdByName(model.Category),
                    VersionId = vsvc.GetVersionIdByName(model.Version),
                    IsUserGenerated = !_userService.ConfirmUserIsAdmin(_userId.ToString())
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Questions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<QuestionListItem> GetQuestions(Guid _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (_userService.ConfirmUserIsAdmin(_userId.ToString()))
                {
                    var adminQuery =
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

                    return adminQuery.ToArray();

                }
                var playerQuery =
                    ctx
                        .Questions
                        .Where(m => m.AuthorId == _userId.ToString())
                        .Select(
                            e =>
                                new QuestionListItem
                                {
                                    QuestionId = e.Id,
                                    Text = e.Text,
                                }
                        );

                return playerQuery.ToArray();
            }
        }
        //add another version of this and and if statement in the controller that accesses one or the other depending on the type of user (admin vs player)
        public QuestionDetail GetQuestionById(int id)
        {
            var asvc = new AnswerService();
            using (var ctx = new ApplicationDbContext())
            {
                if (!_userService.ConfirmUserIsAdmin(_userId.ToString()))
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
                            Answers = playerEntity.Answers
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
                        Answers = adminEntity.Answers
                    };
            }
        }

        public IEnumerable<QuestionDetail> GetQuestionsByCategory(string categoryName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var asvc = GetAnswerService();
                var query =
                    ctx
                        .Questions
                        .Where(e => e.Category.Name == categoryName)
                        .Select(
                            e =>
                                new QuestionDetail
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    Category = e.Category.Name,
                                    Version = e.Version.Name,
                                    Author = e.Author.DisplayName,
                                    Answers = e.Answers
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<QuestionDetail> GetQuestionsByVersion(string versionName)
        {
            var asvc = GetAnswerService();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Questions
                        .Where(e => e.Version.Name == versionName)
                        .Select(
                            e =>
                                new QuestionDetail
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    Category = e.Category.Name,
                                    Version = e.Version.Name,
                                    Author = e.Author.DisplayName,
                                    Answers = e.Answers
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<QuestionDetail> GetQuestionsByVersionId(int id)
        {
            var asvc = GetAnswerService();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Questions
                        .Where(e => e.Version.Id == id)
                        .Select(
                            e =>
                                new QuestionDetail
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    Category = e.Category.Name,
                                    Version = e.Version.Name,
                                    Author = e.Author.DisplayName,
                                   Answers = e.Answers
                                }
                        );

                return query.ToArray();
            }
        }
        public bool UpdateQuestion(QuestionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var vsvc = GetVersionService();
                var csvc = GetCategoryService();
                if (!_userService.ConfirmUserIsAdmin(_userId.ToString()))
                {
                    var playerEntity =
                         ctx
                             .Questions
                             .Single(e => e.Id == model.Id && e.AuthorId == _userId.ToString());
                    playerEntity.Text = model.Text;
                    playerEntity.CategoryId = csvc.GetCategoryIdByName(model.Category);
                    playerEntity.VersionId = vsvc.GetVersionIdByName(model.Version);
                    return ctx.SaveChanges() == 1;
                }
                var adminEntity =
                    ctx
                        .Questions
                        .Single(e => e.Id == model.Id);
                adminEntity.Text = model.Text;
                adminEntity.CategoryId = csvc.GetCategoryIdByName(model.Category);
                adminEntity.VersionId = vsvc.GetVersionIdByName(model.Version);
                return ctx.SaveChanges() == 1;
            }
        }



        public bool DeleteQuestion(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!_userService.ConfirmUserIsAdmin(_userId.ToString()))
                {
                    var userEntity =
                    ctx
                        .Questions
                        .Single(e => e.Id == id && e.AuthorId == _userId.ToString());

                    ctx.Questions.Remove(userEntity);
                    return ctx.SaveChanges() == 1;
                }
                var adminEntity = ctx.Questions.Single(e => e.Id == id);

                ctx.Questions.Remove(adminEntity);
                return ctx.SaveChanges() == 1;
            }
        }
        private CategoryService GetCategoryService()
        {
            return new CategoryService();
        }
        private VersionService GetVersionService()
        {
            return new VersionService();
        }
        private AnswerService GetAnswerService()
        {
            return new AnswerService();
        }
    }
}
