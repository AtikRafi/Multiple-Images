using Microsoft.EntityFrameworkCore;

namespace Multiple_Images.Models
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; } = null!;
        public Microsoft.EntityFrameworkCore.DbSet<Image> Images { get; set; } = null!;
        public DbSet<Variant> Variants { get; set; }

        public DbSet<VariantImage> VariantImages { get; set; } = null!;
    }
}
