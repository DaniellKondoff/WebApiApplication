using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceControlSystem.Api.Controllers;
using SourceControlSystem.Api.Models.Projects;
using System.Web.Http;
using System.Web.Http.Results;

namespace SourceControlSystem.Api.Tests.ControllerTests
{
    [TestClass]
    public class ProjectControllerTest
    {
        [TestMethod]
        public void PostShouldValidateModelState()
        {
            var controller = new ProjectsController(TestObjectFactory.GetProjecService());
            controller.Configuration = new HttpConfiguration();
            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            var result = controller.Post(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            var controller = new ProjectsController(TestObjectFactory.GetProjecService());

            controller.Configuration = new HttpConfiguration();

            var model = TestObjectFactory.GetInvalidModel();

            controller.Validate(model);

            var result = controller.Post(model);

            Assert.AreEqual(typeof(InvalidModelStateResult), result.GetType());
        }
    }
}
