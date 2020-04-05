using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Category;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class CategoryService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public CategoryService() { }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Name = model.Name,
                    Color = model.Color,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Color = e.Color
                                }
                        );

                return query.ToArray();
            }
        }


        public int GetCategoryIdByName(string categoryName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Single(e => e.Name == categoryName);
            return category.Id;
            }
        }

        public List<SelectListItem> GetCategoryStrings()
        {
            List<SelectListItem> versions = new List<SelectListItem>();
            foreach (var category in _context.Categories)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = category.Name;
                selectListItem.Text = category.Name;

                versions.Add(selectListItem);
            }
            return versions;
        }


    }
}
