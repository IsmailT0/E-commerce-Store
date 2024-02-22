using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions  options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
