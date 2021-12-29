using System;

namespace hw11.Exceptions
{
    public class InvalidSyntax : Exception
    {
        public InvalidSyntax(string message)
            : base(message)
        {
        }
    }
}