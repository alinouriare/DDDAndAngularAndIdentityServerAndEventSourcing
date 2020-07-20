using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SmsMessage : AggregateRoot<Guid>
    {
        public string Message { get; set; }

        public string PhoneNumber { get; set; }
    }
}
