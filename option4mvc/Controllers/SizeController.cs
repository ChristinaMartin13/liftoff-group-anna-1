using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class SizeController : Controller
    {
        private PopcornDbContext context;
        public SizeController(PopcornDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sizeList = context.Sizes.ToList();
            return View(sizeList);
        }

        [HttpPost]
        public IActionResult Create(Size size)
        {
            if (ModelState.IsValid)
            {
                context.Sizes.Add(size);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(size);
        }

        [HttpPost]
        public IActionResult Edit(Size size)
        {
            if (ModelState.IsValid)
            {
                context.Entry(size).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(size);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var theSize = context.Sizes.Find(id);

            if (theSize != null)
            {
                context.Sizes.Remove(theSize);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
