using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using store.DataLayer.Model;

namespace store.Api.Data
{
    public class StoreDBContext: IdentityDbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductCode).IsUnique();
            });
            base.OnModelCreating(builder);
        }
    }
}
