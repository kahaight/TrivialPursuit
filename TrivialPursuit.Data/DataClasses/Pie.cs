using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Data.DataClasses
{
    public class Pie
    { 
        [DefaultValue(false)]
        public bool HasBluePiece { get; set; }
        [DefaultValue(false)]
        public bool HasPinkPiece { get; set; }
        [DefaultValue(false)]
        public bool HasYellowPiece { get; set; }
        [DefaultValue(false)]
        public bool HasBrownPiece { get; set; }
        [DefaultValue(false)]
        public bool HasGreenPiece { get; set; }
        [DefaultValue(false)]
        public bool HasOrangePiece { get; set; }

        // bool Full Pie


    }
}
