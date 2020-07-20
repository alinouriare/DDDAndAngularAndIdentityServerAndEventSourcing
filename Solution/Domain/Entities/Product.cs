using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Product:AggregateRoot<Guid>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
