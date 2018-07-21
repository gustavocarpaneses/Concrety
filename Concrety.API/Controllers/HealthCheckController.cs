using Concrety.Core.Interfaces.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace Concrety.API.Controllers
{
    [RoutePrefix("api/HealthCheck")]
    public class HealthCheckController : ApiController
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public IHttpActionResult Check()
        {
            return Ok();
        }

        [HttpGet]
        [Route("database")]
        public async Task<IHttpActionResult> CheckDatabaseAsync()
        {
            var result = await _healthCheckService.CheckAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
