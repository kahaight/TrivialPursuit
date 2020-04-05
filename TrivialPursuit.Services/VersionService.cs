using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Version;
using TrivialPursuitMVC.Data;


namespace TrivialPursuit.Services
{
    public class VersionService
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public VersionService() { }

        public bool CreateVersion(VersionCreate model)
        {
            var entity =
                new GameVersion()
                {
                    Name = model.Name,
                    Description = model.Description,
                    ReleaseYear = model.ReleaseYear
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Versions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VersionListItem> GetVersions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Versions
                        .Select(
                            e =>
                                new VersionListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    ReleaseYear = e.ReleaseYear
                                }
                        );

                return query.ToArray();
            }
        }


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
