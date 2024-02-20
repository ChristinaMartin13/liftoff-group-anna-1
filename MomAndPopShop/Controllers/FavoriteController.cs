using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MomAndPopShop.Data;
using MomAndPopShop.Models;

namespace MomAndPopShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id = 0)
        {
            if (id == 0)
            {
                return Ok(await _context.ApplicationUserFavoritedPopcorns.ToListAsync());
            }
            else
            {
                return Ok(await _context.ApplicationUserFavoritedPopcorns.FindAsync(id));
            }

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ApplicationUserFavoritedPopcorns applicationUserFavoritedPopcorns)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationUserFavoritedPopcorns.Add(applicationUserFavoritedPopcorns);
                await _context.SaveChangesAsync();

                return Ok(applicationUserFavoritedPopcorns);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var theApplicationUserFavoritedPopcorns = await _context.ApplicationUserFavoritedPopcorns.FindAsync(id);

            if (theApplicationUserFavoritedPopcorns != null)
            {
                _context.ApplicationUserFavoritedPopcorns.Remove(theApplicationUserFavoritedPopcorns);
                await _context.SaveChangesAsync();

                return Ok(theApplicationUserFavoritedPopcorns);
            }
            else
            {
                return NotFound();
            }
        }
    }

}
