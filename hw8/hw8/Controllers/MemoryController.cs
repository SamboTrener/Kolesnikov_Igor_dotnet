using Microsoft.AspNetCore.Mvc;

namespace hw8.Controllers
{
    public class MemoryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}