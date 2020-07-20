using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Event
{
   public interface IDomainEvents
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}
