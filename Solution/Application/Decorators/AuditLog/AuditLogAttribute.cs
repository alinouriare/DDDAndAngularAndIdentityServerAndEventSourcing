using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Application.Decorators.AuditLog
{
    [AttributeUsage (AttributeTargets.Class ,Inherited =false,AllowMultiple =true)]
   public sealed class AuditLogAttribute:Attribute
    {
    }
}
