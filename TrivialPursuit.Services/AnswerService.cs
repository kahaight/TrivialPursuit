using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Answer;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class AnswerService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;
        private readonly UserService _userService = new UserService();
        private readonly QuestionService questionService = new QuestionService();
        public AnswerService() { }
        public AnswerService(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;
        }

        public IEnumerable<string> ConvertAnswersToStrings(ICollection<Answer> answers)
        {
            List<string> answerStrings = new List<string>();
            foreach (Answer answer in answers)
            {
                answerStrings.Add(answer.Text);
            }
            return answerStrings;

        }

        public bool CreateAnswer(AnswerCreate model)
        {
            var entity = new Answer
            {
                Text = model.Text,
                QuestiondId = model.QuestionId,
                IsCorrectSpelling = model.IsCorrectSpelling,
                IsUserGenerated = !_userService.ConfirmUserIsAdmin(_userId.ToString()),
                AuthorId = _userId
            };
            _context.Answers.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<AnswerListItem> GetAnswers(string _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (_userService.ConfirmUserIsAdmin(_userId))
                {
                    var adminQuery =
                        ctx
                            .Answers
                            .Select(
                                e =>
                                    new AnswerListItem
                                    {
                                        Id = e.Id,
                                        Text = e.Text,
                                        Question = e.Question.Text
                                    }
                            );
                    return adminQuery.ToArray();
                }
                var playerQuery =
                    ctx
                        .Answers
                        .Where(m => m.AuthorId == _userId)
                        .Select(
                            e =>
                                new AnswerListItem
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    Question = e.Question.Text
                                }
                        );
                return playerQuery.ToArray();
            }
        }
        public AnswerDetail GetAnswerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!_userService.ConfirmUserIsAdmin(_userId.ToString()))
                {
                    var playerEntity =
                         ctx
                             .Answers
                             .Single(e => e.Id == id && e.AuthorId == _userId);
                    return
                        new AnswerDetail
                        {
                            Id = playerEntity.Id,
                            Text = playerEntity.Text,
                            Question = playerEntity.Question.Text,
                            Author = playerEntity.Author.DisplayName,
                            IsCorrectSpelling = playerEntity.IsCorrectSpelling
                        };
                }
                var adminEntity =
                    ctx
                        .Answers
                        .Single(e => e.Id == id);
                return
                    new AnswerDetail
                    {
                        Id = adminEntity.Id,
                        Text = adminEntity.Text,
                        Question = adminEntity.Question.Text,
                        Author = adminEntity.Author.DisplayName,
                        IsCorrectSpelling = adminEntity.IsCorrectSpelling
                    };
            }
        }
        public bool UpdateAnswer(AnswerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (_userService.ConfirmUserIsAdmin(_userId))
                {
                    var adminEntity =
                        ctx
                            .Answers
                            .Single(e => e.Id == model.Id);
                    adminEntity.Text = model.Text;
                    adminEntity.IsCorrectSpelling = model.IsCorrectSpelling;

                    return ctx.SaveChanges() == 1;
                }
                var playerEntity =
                    ctx
                        .Answers
                        .Single(e => e.Id == model.Id && e.AuthorId == _userId);
                playerEntity.Text = model.Text;
                playerEntity.IsCorrectSpelling = model.IsCorrectSpelling;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAnswer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!_userService.ConfirmUserIsAdmin(_userId.ToString()))
                {
                    var userEntity =
                    ctx
                        .Answers
                        .Single(e => e.Id == id && e.AuthorId == _userId);

                    ctx.Answers.Remove(userEntity);
                    return ctx.SaveChanges() == 1;
                }
                var adminEntity = ctx.Answers.Single(e => e.Id == id);

                ctx.Answers.Remove(adminEntity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
