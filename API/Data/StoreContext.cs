using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        //we will be using this as a service and passing in options, 1 of those options are a connection string.
        public StoreContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}