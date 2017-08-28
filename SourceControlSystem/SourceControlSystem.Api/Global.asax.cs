using SourceControlSystem.Api.App_Start;
using SourceControlSystem.Common.Constants;
using System.Reflection;
using System.Web.Http;

namespace SourceControlSystem.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
