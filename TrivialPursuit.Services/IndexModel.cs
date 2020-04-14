using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models.UserModels;

namespace TrivialPursuit.Services
{
    public class IndexModel : PageModel
    {
        public string TotalSort { get; set; }
        public string BlueSort { get; set; }
        public string PinkSort { get; set; }
        public string YellowSort { get; set; }
        public string BrownSort { get; set; }
        public string GreenSort { get; set; }
        public string OrangeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<UserRankingModel> Rankings {get; set;}

        public async Task OnGetAsync(string sortOrder)
        {

        }
    }
}
