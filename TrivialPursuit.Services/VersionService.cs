using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    class VersionService
    {
        public VersionService() { }

        public int GetVersionIdByName(string versionName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var version = ctx.Versions.Single(e => e.Name == versionName);
                return version.Id;
            }
        }
    }
}
