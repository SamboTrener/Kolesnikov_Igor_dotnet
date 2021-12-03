namespace hw8
{
    public class Calculator : ICalculator
    {
        public double Calculate(double val1, Operation operation, double val2)
        {
            double result = 0;
            switch (operation)
            {
                case Operation.Add:
                    result = val1 + val2;
                    break;
                case Operation.Subtract:
                    result = val1 - val2;
                    break;
                case Operation.Multiply:
                    result = val1 * val2;
                    break;
                case Operation.Divide:
                    result = val1 / val2;
                    break;
            }
            return result;
        }
    }
}