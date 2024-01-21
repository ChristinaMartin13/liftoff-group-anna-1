using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class PopcornController : Controller
    {
        private PopcornDbContext context;

        public PopcornController(PopcornDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var popcornList = context.Popcorns.ToList();
            return View(popcornList);
        }

        [HttpPost]
        public IActionResult Create(Popcorn popcorn)
        {
            if(ModelState.IsValid)
            {
                context.Popcorns.Add(popcorn);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(popcorn);
        }

        [HttpPost]
        public IActionResult Edit(Popcorn popcorn)
        {
            if (ModelState.IsValid)
            {
                context.Entry(popcorn).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(popcorn);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var thePopcorn = context.Popcorns.Find(id);

            if (thePopcorn != null)
            {
                context.Popcorns.Remove(thePopcorn);
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
