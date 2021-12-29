using System;

namespace hw11.Exceptions
{
    public class InvalidSymbol: Exception
    {
        public InvalidSymbol(string message)
            : base(message)
        {
        }
    }
}