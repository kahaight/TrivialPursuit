using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;

namespace TrivialPursuit.Services
{
    public class AnswerService
    {
        public AnswerService() { }
        public IEnumerable<string> ConvertAnswersToStrings(ICollection<Answer> answers)
        {
            List<string> answerStrings = new List<string>();
            foreach(Answer answer in answers)
            {
                answerStrings.Add(answer.Text);
            }
            return answerStrings;

        }
    }
}
