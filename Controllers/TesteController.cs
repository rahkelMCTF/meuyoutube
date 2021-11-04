using Microsoft.AspNetCore.Mvc;

namespace meuyoutube.Controllers
{
    public class TesteController : Controller
    {
        public TesteController(){

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}