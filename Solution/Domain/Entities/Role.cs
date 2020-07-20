using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
  public  class Role:AggregateRoot<Guid>
    {

        public virtual string Name { get; set; }

        public virtual string NormalizedName { get; set; }

        public virtual string ConcurrencyStamp { get; set; }

        public IList<RoleClaim> Claims { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
