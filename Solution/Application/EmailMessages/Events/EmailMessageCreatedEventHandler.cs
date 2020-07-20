using Domain.Entities;
using Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmailMessages.Events
{
    public class EmailMessageCreatedEventHandler : IDomainEventHandler<EntityCreatedEvent<EmailMessage>>
    {
        public EmailMessageCreatedEventHandler()
        {
        }

        public void Handle(EntityCreatedEvent<EmailMessage> domainEvent)
        {
            // Handle the event here and we can also forward to external systems
        }
    }
}
