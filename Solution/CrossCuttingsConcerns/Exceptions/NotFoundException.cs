using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrossCuttingsConcerns.Exceptions
{
   public class NotFoundException:Exception
    {

        public NotFoundException():base()
        {

        }

        public NotFoundException(string message):base (message)
        {

        }
    }
}
