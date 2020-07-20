using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Event
{
   public interface IDomainEventHandler<T> where T:IDomainEvent
    {

        void Handle(T domainEvent);
    }
}
