using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Event
{
    public class EntityDeletedEvent<T> : IDomainEvent
          where T : Entity<Guid>
    {
        public EntityDeletedEvent(T entity, DateTime eventDateTime)
        {
            Entity = entity;
            EventDateTime = eventDateTime;
        }

        public T Entity { get; }

        public DateTime EventDateTime { get; }
    }
}
