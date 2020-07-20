using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Event
{
  public  class EntityCreatedEvent<T>:IDomainEvent where T:Entity<Guid>
    {

        public EntityCreatedEvent(T entity, DateTime eventDateTime)
        {
            Entity = entity;
            EventDateTime = eventDateTime;
        }

        public T Entity { get; }

        public DateTime EventDateTime { get; }
    }
}
