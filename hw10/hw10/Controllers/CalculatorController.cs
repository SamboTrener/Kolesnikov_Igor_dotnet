using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using hw10.Interfaces;
using hw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw10.Controllers
{
    
    public class CalculatorController : Controller
    {
        public IActionResult Calculate([FromServices] ICalculator calculator, string input)
        {
            try
            {
                var resultToCache = calculator.Calculate(input);
                return Content(resultToCache.ToString(CultureInfo.InvariantCulture));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}