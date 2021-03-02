using FrontEnd.Models;
using FrontEnd.WebServices.Abstract;
using FrontEnd.WebServices.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontEnd.WebServices.Concrete
{
    public class RestEventsService : IEventsService
    {
        private readonly HttpClient _httpClient;

        public RestEventsService(IOptions<ConfigEventService> config)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(config.Value.URL);
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            var resource = "/api/event";
            var response = await _httpClient.GetAsync(resource);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<EventModel>>(result);
            }
            return Enumerable.Empty<EventModel>();
        }
        public async Task<IEnumerable<EventModel>> GetEventsWithNNumericValue()
        {
            var resource = "/api/event/numericValue";
            var response = await _httpClient.GetAsync(resource);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<EventModel>>(result);
            }
            return Enumerable.Empty<EventModel>();
        }
    }
}
