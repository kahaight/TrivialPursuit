using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuitMVC.Data;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuit.Services
{
    public class QuestionService
    {
        private CategoryService _categoryService = new CategoryService();
        private UserService _userService = new UserService();
        private readonly Guid _userId;
        public QuestionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateQuestion(QuestionCreate model)
        {
            var entity =
                new Question()
                {
                    AuthorId = _userId.ToString(),
                    Text = model.Text,
                    CategoryId = _categoryService.GetCategoryIdByName(model.Category),
                    IsUserGenerated = _userService.ConfirmUserIsPlayer(_userId.ToString())
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Questions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
