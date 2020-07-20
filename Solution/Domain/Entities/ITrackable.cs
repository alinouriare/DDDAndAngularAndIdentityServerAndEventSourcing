using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
  public interface ITrackable
    {
        byte[] RowVersion { get; set; }
    }
}
