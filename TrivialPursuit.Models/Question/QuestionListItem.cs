﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrivialPursuit.Models.Question
{
    public class QuestionListItem
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public TrivialPursuit.Data.DataClasses.Category Category { get; set; }
        public TrivialPursuit.Data.DataClasses.GameVersion GameVersion { get; set; }

    }
}