using Api.Sample.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// Endpoint responsável por inserir os eventos.
        /// </summary>
        /// <param name="dtoInsertEvent"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] DtoInsertEvent dtoInsertEvent)
        {
            return await Task.FromResult(Ok(dtoInsertEvent));
        } 
    }
}
