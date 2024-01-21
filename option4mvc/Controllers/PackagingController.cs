using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class PackagingController : Controller
    {
        private PopcornDbContext context;
        public PackagingController(PopcornDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var packagingList = context.Packagings.ToList();
            return View(packagingList);
        }

        [HttpPost]
        public IActionResult Create(Packaging packaging)
        {
            if (ModelState.IsValid)
            {
                context.Packagings.Add(packaging);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(packaging);
        }

        [HttpPost]
        public IActionResult Edit(Packaging packaging)
        {
            if (ModelState.IsValid)
            {
                context.Entry(packaging).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(packaging);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var thePackaging = context.Packagings.Find(id);

            if (thePackaging != null)
            {
                context.Packagings.Remove(thePackaging);
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
