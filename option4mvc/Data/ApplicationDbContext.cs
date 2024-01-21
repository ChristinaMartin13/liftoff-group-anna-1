using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using option4mvc.Models;

namespace option4mvc.Data
{
    //Below, the ApplicationUser subclass is referenced instead of the default IdentitiyUser class
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}