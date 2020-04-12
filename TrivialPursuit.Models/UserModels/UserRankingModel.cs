using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Models.UserModels
{
    public class UserRankingModel
    {
        public ApplicationUser Player { get; set; }
        public int? BluePercentage { get; set; }
        public int? PinkPercentage { get; set; }
        public int? YellowPercentage { get; set; }
        public int? BrownPercentage { get; set; }
        public int? GreenPercentage { get; set; }
        public int? OrangePercentage { get; set; }

    }
}
