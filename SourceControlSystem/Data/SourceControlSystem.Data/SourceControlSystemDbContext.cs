using Microsoft.AspNet.Identity.EntityFramework;
using SourceControlSystem.Models;
using System.Data.Entity;

namespace SourceControlSystem.Data
{
    public class SourceControlSystemDbContext : IdentityDbContext<User>,ISourceControlSystemDbContext
    {
        public SourceControlSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Commit> Commits { get; set; }
        public virtual IDbSet<SoftwareProject> SoftwareProjects { get; set; }


        public static SourceControlSystemDbContext Create()
        {
            return new SourceControlSystemDbContext();
        }
    }
}
