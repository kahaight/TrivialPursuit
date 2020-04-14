﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Models.UserModels
{
    public class UserRankingModel
    {
        public int BlueAnswered { get; set; }
        public int BlueCorrect { get; set; }
        public int PinkAnswered { get; set; }
        public int PinkCorrect { get; set; }
        public int YellowAnswered { get; set; }
        public int YellowCorrect { get; set; }
        public int BrownAnswered { get; set; }
        public int BrownCorrect { get; set; }
        public int GreenAnswered { get; set; }
        public int GreenCorrect { get; set; }
        public int OrangeAnswered { get; set; }
        public int OrangeCorrect { get; set; }
        public int TotalAnswered { get
            {
                return BlueAnswered + PinkAnswered + YellowAnswered + BrownAnswered + GreenAnswered + OrangeAnswered;
            } }
        public int TotalCorrect
        {
            get
            {
                return BlueCorrect + PinkCorrect + YellowCorrect + BrownCorrect + GreenCorrect + OrangeCorrect;
            }
        }
        public double TotalPercentage
        {
            get
            {
                if (TotalAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(TotalCorrect) / Convert.ToDouble(TotalAnswered);
            }
        }
        public double BluePercentage
        {
            get
            {
                if(BlueAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(BlueCorrect) / Convert.ToDouble(BlueAnswered);
            }
        }
        public double PinkPercentage
        {
            get
            {
                if (PinkAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(PinkCorrect) / Convert.ToDouble(PinkAnswered);
            }
        }
        public double YellowPercentage
        {
            get
            {
                if (YellowAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(YellowCorrect) / Convert.ToDouble(YellowAnswered);
            }
        }
        public double BrownPercentage
        {
            get
            {
                if (BrownAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(BrownCorrect) / Convert.ToDouble(BrownAnswered);
            }
        }
        public double GreenPercentage
        {
            get
            {
                if (GreenAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(GreenCorrect) / Convert.ToDouble(GreenAnswered);
            }
        }
        public double OrangePercentage
        {
            get
            {
                if (OrangeAnswered == 0)
                {
                    return 0d;
                }
                return Convert.ToDouble(OrangeCorrect) / Convert.ToDouble(OrangeAnswered);
            }
        }

    }
}
