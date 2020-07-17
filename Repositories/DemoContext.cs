using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories{
    //Mapeia os Models com o DB
    public class DemoContext : DbContext{

        public DemoContext(DbContextOptions<DemoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> products { get; set; }
    }
}