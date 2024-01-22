using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using option4mvc.Data;
using option4mvc.Models;

namespace option4mvc.Controllers
{
    public class SeasoningController : Controller
    {
        private ApplicationDbContext _context;
        public SeasoningController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var seasoningList = _context.Seasonings.ToList();
            return View(seasoningList);
        }

        [HttpPost]
        public IActionResult Create(Seasoning seasoning)
        {
            if (ModelState.IsValid)
            {
                _context.Seasonings.Add(seasoning);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(seasoning);
        }

        [HttpPost]
        public IActionResult Edit(Seasoning seasoning)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(seasoning).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(seasoning);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var theSeasoning = _context.Seasonings.Find(id);

            if (theSeasoning != null)
            {
                _context.Seasonings.Remove(theSeasoning);
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
