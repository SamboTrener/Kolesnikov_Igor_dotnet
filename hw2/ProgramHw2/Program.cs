using System;
using hw2;

namespace ProgramHw2
{
    public static class Program
    {
        private const int WrongArgFormat = 1;
        private const int WrongArgLen = 2;
        private const int WrongOperationFormat = 3;

        internal enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            None
        }; 

        public static int Main(string[] args)
        {
            if (CheckArgLength(args.Length))
            {
                return WrongArgLen;
            }

            if (!Parser.TryParseOrQuit(args[0], out var val1) || !Parser.TryParseOrQuit(args[2], out var val2))
            {
                return WrongArgFormat;
            }
            
            if (Parser.TryParseOperationOrQuit(args[1], out var operation))
            {
                return WrongOperationFormat;
            }

            var result = Calculator.Calculate(operation, val1, val2);
            Console.WriteLine($"Result is: {result}");
            return 0;
        }

        private static bool CheckArgLength(int argsLen)
        {
            if (argsLen == 3) return false;
            Console.WriteLine($"The program requires 3 CLI arguments but {argsLen} provided");
            return true;
        }
    }
}