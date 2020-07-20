using Domain.Entities;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SmsMessages.Events
{
    public class SmsMessageCreatedEventHandler : IDomainEventHandler<EntityCreatedEvent<SmsMessage>>
    {
        public SmsMessageCreatedEventHandler()
        {
        }

        public void Handle(EntityCreatedEvent<SmsMessage> domainEvent)
        {
            // Handle the event here and we can also forward to external systems
        }
    }
}
