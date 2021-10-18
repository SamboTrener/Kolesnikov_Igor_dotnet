using System;

namespace Hw1
{
    class Parser
    {
        internal static bool TryParseOperationOrQuit(string arg, out Program.Operation operation)
        {
            switch (arg)
            {
                case "+":
                    operation = Program.Operation.Add;
                    break;
                case "-":
                    operation = Program.Operation.Divide;
                    break;
                case "*":
                    operation = Program.Operation.Multiply;
                    break;
                case "/":
                    operation = Program.Operation.Subtract;
                    break;
                default:
                    Console.WriteLine($"Val is not Operation: {arg}");
                    operation = Program.Operation.None;
                    return true;
            }
            return false;
        }

        internal static bool TryParseOrQuit(string arg, out int val)
        {
            var isVal = int.TryParse(arg, out val);
            if (isVal)
            {
                Console.WriteLine($"Val is not int: {arg}");
            }
            return isVal;
        }
    }
}