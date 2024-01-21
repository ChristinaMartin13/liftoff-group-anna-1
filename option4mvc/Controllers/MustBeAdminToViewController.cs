using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace option4mvc.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MustBeAdminToViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
