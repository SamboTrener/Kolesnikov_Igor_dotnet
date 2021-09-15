namespace Hw1
{
    internal static class Calculator
    {
        internal static int Calculate(Program.Operation operation, int val1, int val2)
        {
            var result = 0;
            switch (operation)
            {
                case Program.Operation.Add:
                    result = val1 + val2;
                    break;
                case Program.Operation.Subtract:
                    result = val1 - val2;
                    break;
                case Program.Operation.Multiply:
                    result = val1 * val2;
                    break;
                case Program.Operation.Divide:
                    result = val1 / val2;
                    break;
            }
            return result;
        }
    }
}