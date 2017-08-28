using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceControlSystem.Models
{
    public class SoftwareProject
    {
        public int Id { get; set; }

        public SoftwareProject()
        {
            this.Users = new HashSet<User>();
            this.Commits = new HashSet<Commit>();
        }

        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Private { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
