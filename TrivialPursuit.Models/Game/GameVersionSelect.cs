using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models.Version;

namespace TrivialPursuit.Models.Game
{
    public class GameVersionSelect
    {
        public IEnumerable<VersionListItem> Versions { get; set; }
    }
}
