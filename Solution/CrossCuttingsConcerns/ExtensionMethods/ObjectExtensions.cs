using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingsConcerns.ExtensionMethods
{
   public static class ObjectExtensions
    {
        public static string AsJsonString(this object obj)
        {
            var content = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return content;
        }
    }
}
