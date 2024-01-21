using Microsoft.EntityFrameworkCore;
using option4mvc.Models;

namespace option4mvc.Data
{
    public class PopcornDbContext : DbContext
    {
        public DbSet<Popcorn> Popcorns { get; set; }

        public DbSet<Seasoning> Seasonings { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Packaging> Packagings { get; set; }

        public PopcornDbContext(DbContextOptions<PopcornDbContext> options) : base(options)
        {
        }

    }
}
