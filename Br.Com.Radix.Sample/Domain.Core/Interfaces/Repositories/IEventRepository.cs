using Domain.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task<IQueryable<Event>> GetAll(Expression<Func<Event, bool>> query = null);
        Task<Event> GetById(Guid id);
        Task<Event> Insert(Event ev);
        Task<Event> Update(Event ev);
        Task<int> Save();

    }
}
