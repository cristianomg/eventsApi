using FrontEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEnd.WebServices.Abstract
{
    public interface IEventsService
    {
        Task<IEnumerable<EventModel>> GetEvents();
        Task<IEnumerable<EventModel>> GetEventsWithNNumericValue();
    }
}
