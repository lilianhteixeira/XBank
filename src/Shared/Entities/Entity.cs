using System;

namespace XBank.Domain.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
            IsActive = true;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
