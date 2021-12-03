using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Calculate([FromServices] ICalculator calculator, [FromServices] IParser parser,
            string val1, string operation, string val2)
        {
            if (!parser.TryParseOrQuit(val1, out var val1Parsed) || !parser.TryParseOrQuit(val2, out var val2Parsed))
            {
                return BadRequest("WrongArgFormat");
            }

            if (parser.TryParseOperationOrQuit(operation, out var operationParsed))
            {
                return BadRequest("WrongOperationFormat");
            }

            return Content(calculator.Calculate(val1Parsed, operationParsed, val2Parsed).ToString(CultureInfo.InvariantCulture));
        }
    }
}