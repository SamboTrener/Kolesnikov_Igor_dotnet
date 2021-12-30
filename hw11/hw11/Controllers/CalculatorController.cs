using System;
using System.Globalization;
using hw11.Exceptions;
using hw11.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hw11.Controllers
{
    public class CalculatorController : Controller
    {
        
        public IActionResult Calculate([FromServices] ICalculator calculator, IExceptionHandler exceptionHandler, string input)
        {
            try
            {
                var resultToCache = calculator.Calculate(input);
                return Content(resultToCache.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                exceptionHandler.HandleException(e);
                return Content(e.Message);
            }
        }
    }
}