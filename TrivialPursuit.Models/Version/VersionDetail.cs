using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models.Question;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuit.Models.Version
{
    public class VersionDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<QuestionDetail> Questions { get; set; }
    }
}
