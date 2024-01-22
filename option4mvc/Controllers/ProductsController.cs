using Microsoft.AspNetCore.Mvc;

namespace option4mvc.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
