using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Data.DataClasses
{
    public class GameVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
