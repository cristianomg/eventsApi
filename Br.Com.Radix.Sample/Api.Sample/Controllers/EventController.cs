using Api.Sample.Dtos;
using Api.Sample.Hubs;
using AutoMapper;
using Domain.Core.Entities;
using Domain.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHubContext<EventHub> _streaming;
        public EventController(IMapper mapper,
            IEventRepository eventRepository,
            IHubContext<EventHub> streaming) 
            : base(mapper)
        {
            _eventRepository = eventRepository;
            _streaming = streaming;
        }
        /// <summary>
        /// Endpoint responsável por retornar todos os eventos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.ProjectTo<DtoEvent>(await _eventRepository.GetAll()));
        /// <summary>
        /// Endpoint respónsavel por retornar todos os eventos com valor numerico.
        /// </summary>
        /// <returns></returns>
        [HttpGet("numericValue")]
        public async Task<IActionResult> GetAllWithNumericValue()
        {
            var events = await _eventRepository.GetAll();
            var filteredEvents = events
                .ToList()
                .Where(x => !string.IsNullOrEmpty(x.Value) &&
                            x.Value.Replace(".", string.Empty).All(char.IsDigit));

            return Ok(_mapper.Map<IEnumerable<DtoEvent>>(filteredEvents));
        }
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

            await WriteOnStream(_mapper.Map<DtoEvent>(eventAdded), "post");

            return CreatedAtAction(nameof(GetAll), new { status = result });
        }
        private async Task WriteOnStream(DtoEvent data, string action)
        {
            string jsonData = string.Format("{0}\n", JsonSerializer.Serialize(new { data, action }));

            //Utiliza o Hub para enviar uma mensagem para ReceiveMessage
            await _streaming.Clients.All.SendAsync("ReceiveMessage", jsonData);
        }
    }
}
