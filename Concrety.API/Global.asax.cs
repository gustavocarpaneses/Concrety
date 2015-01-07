using Concrety.API.AutoMapper;
using System.Web;

namespace Concrety.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}
