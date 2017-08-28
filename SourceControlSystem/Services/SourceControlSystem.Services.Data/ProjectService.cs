using System;
using System.Collections.Generic;
using System.Linq;
using SourceControlSystem.Models;
using SourceControlSystem.Data;
using SourceControlSystem.Data.Repository;
using SourceControlSystem.Common.Constants;

namespace SourceControlSystem.Services.Data
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<SoftwareProject> datprojectDataa;
        private readonly IRepository<User> usersData;
        public ProjectService(IRepository<SoftwareProject> projectsRepo,IRepository<User>usersRepo )
        {
            this.datprojectDataa = projectsRepo;
            this.usersData = usersRepo;
        }

        public int Add(string name, string description, string creator, bool isPrivate = false)
        {
            var currentUser = this.usersData.All().FirstOrDefault(u => u.UserName == creator);

            var newProject = new SoftwareProject
            {
                Name = name,
                Description = description,
                Private = isPrivate,
                CreatedOn = DateTime.Now
            };

            newProject.Users.Add(currentUser);

            this.datprojectDataa.Add(newProject);
            this.datprojectDataa.SaveChanges();

            return newProject.Id;
        }

        public IQueryable<SoftwareProject> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.datprojectDataa.All()
               .OrderByDescending(p => p.CreatedOn)
               .Skip((page - 1) * pageSize)
               .Take(pageSize);
        }
    }
}
