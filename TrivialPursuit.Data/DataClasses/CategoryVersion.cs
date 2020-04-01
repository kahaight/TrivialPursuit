using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Data.DataClasses
{
    public class CategoryVersion
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(Version))]
        public int VersionId { get; set; }
        public virtual Version Version { get; set; }

    }
}
