using Microsoft.EntityFrameworkCore;

using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class SnowDbContext : DbContext
    {
        public SnowDbContext(DbContextOptions<SnowDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
