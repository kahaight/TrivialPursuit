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
        public AnswerService() { }
        public AnswerService(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;
        }

        public IEnumerable<string> ConvertAnswersToStrings(ICollection<Answer> answers)
        {
            List<string> answerStrings = new List<string>();
            foreach(Answer answer in answers)
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
                IsUserGenerated = _userService.ConfirmUserIsPlayer(_userId.ToString())
            };
            _context.Answers.Add(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
