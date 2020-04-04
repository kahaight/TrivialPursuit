using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class VersionService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public VersionService() { }

        public int GetVersionIdByName(string versionName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var version = ctx.Versions.Single(e => e.Name == versionName);
                return version.Id;
            }
        }

        public List<SelectListItem> GetVersionStrings()
        {
            List<SelectListItem> versions = new List<SelectListItem>();
            foreach(var version in _context.Versions)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = version.Name;
                selectListItem.Text = version.Name;

                versions.Add(selectListItem);
            }
            return versions;
        }
    }
}
