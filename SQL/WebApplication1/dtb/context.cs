using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.dtb
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }
    }
}