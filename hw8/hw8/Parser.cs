using System;

namespace hw8
{
    public class Parser : IParser
    {
        bool IParser.TryParseOperationOrQuit(string arg, out Operation operation)
        {
            switch (arg)
            {
                case "add":
                    operation = Operation.Add;
                    break;
                case "-":
                    operation = Operation.Subtract;
                    break;
                case "*":
                    operation = Operation.Multiply;
                    break;
                case "/":
                    operation = Operation.Divide;
                    break;
                default:
                    Console.WriteLine($"Val is not Operation: {arg}");
                    operation = Operation.None;
                    return true;
            }
            return false;
        }

        bool IParser.TryParseOrQuit(string arg, out double val)
        {
            var isVal = double.TryParse(arg, out val);
            if (!isVal)
            {
                Console.WriteLine($"Val is not double: {arg}");
            }
            return isVal;
        }
    }
}