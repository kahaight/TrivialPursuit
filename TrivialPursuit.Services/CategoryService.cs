using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        public int GetCategoryIdByName(string categoryName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Single(e => e.Name == categoryName);
            return category.Id;
            }
        }
    }
}
