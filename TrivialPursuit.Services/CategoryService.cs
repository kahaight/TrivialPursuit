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
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var qsvc = GetQuestionService();
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.Id == id);
                return
                    new CategoryDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Color = entity.Color,
                        Questions = qsvc.GetQuestionsByCategory(entity.Name)
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Color = model.Color;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.Id == id);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
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

        public QuestionService GetQuestionService()
        {
            return new QuestionService();
        }
    }
}
