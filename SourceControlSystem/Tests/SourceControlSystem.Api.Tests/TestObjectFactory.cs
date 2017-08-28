using SourceControlSystem.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SourceControlSystem.Api.Models.Projects;

namespace SourceControlSystem.Api.Tests
{
    public static class TestObjectFactory
    {
        public  static IProjectService GetProjecService()
        {
            var projectService = new Mock<IProjectService>();
            projectService.Setup(pr => pr.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<bool>()
                )).Returns(1);

            return projectService.Object;
        }

        public static SaveProjectRequestModel GetInvalidModel()
        {
            return new SaveProjectRequestModel { Description = "TestDescription" };
        }
    }
}
