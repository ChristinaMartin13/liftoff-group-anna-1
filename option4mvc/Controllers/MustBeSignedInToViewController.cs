using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace option4mvc.Controllers
{
    [Authorize]
    public class MustBeSignedInToViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
