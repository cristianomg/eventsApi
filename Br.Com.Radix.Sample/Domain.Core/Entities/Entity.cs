using System;

namespace Domain.Core.Entities
{
    public abstract class Entity<T>
    {
        public Entity()
        {
            CreateAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public T Id { get; set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
    }
}
