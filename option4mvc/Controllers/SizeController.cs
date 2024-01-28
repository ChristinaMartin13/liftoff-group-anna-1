using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class SizeController : Controller
    {
        private ApplicationDbContext _context;
        public SizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sizeList = _context.Sizes.ToList();
            return View(sizeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Size size = new Size();
            return View(size);
        }

        [HttpPost]
        public IActionResult Create(Size size)
        {
            if (ModelState.IsValid)
            {

                _context.Sizes.Add(size);
                _context.SaveChanges();

                return Redirect("Index");
            }
            return View("Create", size);
        }

        [HttpPost]
        public IActionResult Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(size).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(size);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var theSize = _context.Sizes.Find(id);

            if (theSize != null)
            {
                _context.Sizes.Remove(theSize);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
