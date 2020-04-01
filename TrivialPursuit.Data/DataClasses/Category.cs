using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Data.DataClasses
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual ICollection<CategoryVersion> CategoryVersions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
