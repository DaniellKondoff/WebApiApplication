using SourceControlSystem.Api.Models.Projects;
using SourceControlSystem.Common.Constants;
using SourceControlSystem.Services.Data;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using SourceControlSystem.Models;

namespace SourceControlSystem.Api.Controllers
{
    public class ProjectsController : ApiController
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [EnableCors("*","*","*")]
        public IHttpActionResult Get()
        {
            var result = this.projectService.All(page : 1)
                .ProjectTo<SoftwareProjectsDTO>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        public IHttpActionResult Get(string id)
        {

            if (String.IsNullOrEmpty(id))
            {
                return this.BadRequest("Priject Name cannot be null or empty.");
            }

            var result = this.projectService.All()
                .Where(pr => 
                pr.Name == id && 
                (!pr.Private || (pr.Private && pr.Users.Any(c => c.UserName == this.User.Identity.Name))))
                .ProjectTo<SoftwareProjectsDTO>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        public IHttpActionResult Post(SaveProjectRequestModel model)
        {
            var dbModel =  Mapper.Map<SoftwareProject>(model);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.projectService.Add(model.Name, model.Description, this.User.Identity.Name, model.IsPrivate);
            return this.Ok(createdProjectId);
        }

        [Route("api/projects/all")]
        public IHttpActionResult Get(int page, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.projectService.All(page,pageSize)
                .ProjectTo<SoftwareProjectsDTO>()
                .ToList();

            return this.Ok(result);
        }
    }
}
