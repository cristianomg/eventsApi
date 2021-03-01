using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.Tasks;

namespace Api.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HealthController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }
        /// <summary>
        /// Obtém o status da API
        /// </summary>
        /// <remarks>Provém uma indicação da saúde da API</remarks>
        /// <response code="200">Relatório de saúde da API</response>
        [HttpGet]
        [ProducesResponseType(typeof(HealthReport), StatusCodes.Status200OK)]
        public async Task<HealthReport> Get() => await _healthCheckService.CheckHealthAsync();
    }
}
