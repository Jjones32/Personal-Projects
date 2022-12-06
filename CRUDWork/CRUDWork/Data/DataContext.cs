using Microsoft.EntityFrameworkCore;
using CRUDWork.Models;

namespace CRUDWork.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; } 
    }
}
