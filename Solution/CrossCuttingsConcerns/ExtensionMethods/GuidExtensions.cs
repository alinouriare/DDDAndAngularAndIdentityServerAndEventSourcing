﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingsConcerns.ExtensionMethods
{
  public static  class GuidExtensions
    {

        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return guid == null || guid == Guid.Empty;
        }
    }
}
