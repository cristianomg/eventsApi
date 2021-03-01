using Data.Core.Context;
using Domain.Core.Entities;
using Domain.Core.Interfaces.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly CoreContext _context;
        public EventRepository(CoreContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Event>> GetAll(Expression<Func<Event, bool>> query = null)
        {
            if (query != null)
            {
                return await Task.FromResult(_context.Events.Where(query).AsQueryable()); 
            }
            return await Task.FromResult(_context.Events.AsQueryable());
        }

        public async Task<Event> GetById(Guid id)
            => await _context.Events.FindAsync(id);

        public async Task<Event> Insert(Event ev)
        {
            var addedEvent = await _context.Events.AddAsync(ev);
            return addedEvent.Entity;
        }

        public async Task<Event> Update(Event ev)
            => await Task.FromResult(_context.Events.Update(ev).Entity);
        public async Task<int> Save()
            => await _context.SaveChangesAsync();
    }
}
