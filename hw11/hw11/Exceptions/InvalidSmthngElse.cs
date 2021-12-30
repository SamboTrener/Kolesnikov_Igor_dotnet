using System;

namespace hw11.Exceptions
{
    public class InvalidSmthngElse: Exception
    {
        public InvalidSmthngElse(string message)
            : base(message)
        {
        }
    }
}