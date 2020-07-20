using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Identity
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }

        Guid UserId { get; }
    }
}
