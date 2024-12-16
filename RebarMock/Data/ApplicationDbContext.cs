using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RebarMock.Models;

namespace RebarMock.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products {get;set; } 
        public DbSet<Category> Categories {get;set; } 
        public DbSet<Ingredient> Ingredients {get;set; } 
    }
}
