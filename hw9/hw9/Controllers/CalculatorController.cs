using System.Globalization;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using hw9.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw9.Controllers
{
    
    public class CalculatorController : Controller
    {
        public IActionResult Calculate([FromServices] ICalculator calculator, string input)
        {
            try
            {
                return Content(calculator.Calculate(input).ToString(CultureInfo.InvariantCulture));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}