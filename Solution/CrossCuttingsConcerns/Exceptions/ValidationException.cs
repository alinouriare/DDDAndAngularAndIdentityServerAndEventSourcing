using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuttingsConcerns.Exceptions
{
  public class ValidationException:Exception
    {
        public static void Requires(bool expected,string messge)
        {
            if (!expected)
                throw new ValidationException(messge);
        }
        public ValidationException(string message):base(message)
        {

        }

        public ValidationException(string message,Exception innerException):base(message,innerException)
        {

        }
    }
}
