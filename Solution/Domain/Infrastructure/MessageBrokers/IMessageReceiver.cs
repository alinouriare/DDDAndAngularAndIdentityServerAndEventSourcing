using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.MessageBrokers
{
  public  interface IMessageReceiver<T>
    {
        void Receive(Action<T> action);
    }
}
