using System;

namespace Domain.Core.Entities
{
    public abstract class Entity<T>
    {
        public Guid Id { get; set; }
    }
}
