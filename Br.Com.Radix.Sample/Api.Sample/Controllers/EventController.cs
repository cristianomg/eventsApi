using Api.Sample.Dtos;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IMapper mapper, IEventRepository eventRepository) 
            : base(mapper)
        {
            _eventRepository = eventRepository;
        }
        /// <summary>
        /// Endpoint responsável por retornar todos os eventos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.ProjectTo<DtoEvent>(await _eventRepository.GetAll()));
        /// <summary>
        /// Endpoint responsável por inserir os eventos.
        /// </summary>
        /// <param name="dtoInsertEvent"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DtoInsertEvent dtoInsertEvent)
        {
            var entity = _mapper.Map<Event>(dtoInsertEvent);

            if (string.IsNullOrEmpty(entity.Value))
                entity.Status = EventStatus.Erro;
            else
                entity.Status = EventStatus.Processed;

            var eventAdded = await _eventRepository.Insert(entity);

            await _eventRepository.Save();

            var result = eventAdded.Status == EventStatus.Processed ?
                "processed" : "erro";

            return Ok(new { status = result });
        } 
    }
}
