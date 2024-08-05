using Microsoft.EntityFrameworkCore;

namespace Project1.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Entities.Products> Products { get; set; }

        }
        
            
        
    }

