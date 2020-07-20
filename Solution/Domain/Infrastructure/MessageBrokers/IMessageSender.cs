using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.MessageBrokers
{
    public interface IMessageSender<T>
    {
        void Send(T message);
    }
}
