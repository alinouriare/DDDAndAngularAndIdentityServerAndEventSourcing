using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public abstract class Entity<TKey> : IHasKey<TKey>, ITrackable
    {
        public TKey id { get ; set ; }


        [Timestamp]
        public byte[] RowVersion { get ; set ; }
    }
}
