using Lemontech.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Lemontech.DataLayer.Entities
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
