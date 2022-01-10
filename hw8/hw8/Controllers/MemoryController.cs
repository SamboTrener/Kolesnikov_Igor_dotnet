using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    
    public class MemoryController : Controller
    {
        public static string str ="";
        
        public IActionResult Index()
        {
            for (int i = 0; i < 100; i++)
            {
                str = str + i.ToString();
            }
            return Ok();
        }
    }
}