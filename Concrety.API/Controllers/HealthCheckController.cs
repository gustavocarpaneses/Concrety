using System.Web.Http;

namespace Concrety.API.Controllers
{
    [RoutePrefix("api/HealthCheck")]
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
