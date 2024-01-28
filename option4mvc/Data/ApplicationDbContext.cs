using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using option4mvc.Models;

namespace option4mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Popcorn> Popcorns { get; set; }

        public DbSet<Seasoning> Seasonings { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Packaging> Packagings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}