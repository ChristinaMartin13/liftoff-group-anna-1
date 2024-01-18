using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;


namespace option4mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public IActionResult Index ()
        {
            List<Cart> carts = _context.Cart.ToList();

            return View(carts);
        }*/

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            if (_context.Cart != null)
            {
                return View(await _context.Cart.ToListAsync());
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
            }
        }
    }
}
