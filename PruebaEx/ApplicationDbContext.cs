using Microsoft.EntityFrameworkCore;
using PruebaEx.Entities;

namespace PruebaEx
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


    }
}
