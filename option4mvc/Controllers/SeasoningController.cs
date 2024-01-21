using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class SeasoningController : Controller
    {
        private PopcornDbContext context;
        public SeasoningController(PopcornDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var seasoningList = context.Seasonings.ToList();
            return View(seasoningList);
        }

        [HttpPost]
        public IActionResult Create(Seasoning seasoning)
        {
            if (ModelState.IsValid)
            {
                context.Seasonings.Add(seasoning);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(seasoning);
        }

        [HttpPost]
        public IActionResult Edit(Seasoning seasoning)
        {
            if (ModelState.IsValid)
            {
                context.Entry(seasoning).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(seasoning);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var theSeasoning = context.Seasonings.Find(id);

            if (theSeasoning != null)
            {
                context.Seasonings.Remove(theSeasoning);
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
