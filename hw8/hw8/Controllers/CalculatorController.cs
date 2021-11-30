using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly Calculator calculator;

        public CalculatorController(Calculator calculator)
        {
            this.calculator = calculator;
        }
        
        public double Add([FromServices] ICalculator calculator, double a, double b) => calculator.Add(a, b);

        public double Subtract([FromServices] ICalculator calculator, double a, double b) => calculator.Subtract(a, b);

        public double Multiply([FromServices] ICalculator calculator, double a, double b) => calculator.Multiply(a, b);

        public double Divide([FromServices] ICalculator calculator, double a, double b) => calculator.Divide(a, b);
    }
}