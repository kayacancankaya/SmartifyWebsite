using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartifyWebsite.Data;
using static NuGet.Packaging.PackagingConstants;
using System.Security.Claims;
namespace SmartifyWebsite.Models
{
	public class SmartifyDbContext : DbContext
	{

		public SmartifyDbContext(DbContextOptions<SmartifyDbContext> options) : base(options) { }
        public SmartifyDbContext()
        {
            
        }
        public DbSet<Product> Product { get; set; }
		public DbSet<ProductCategory> ProductCategory { get; set; }
		public DbSet<PricingList> PricingList { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Product>()
						 .HasKey(i => i.Id);

			modelBuilder.Entity<ProductCategory>()
						 .HasKey(i => i.Id);
			modelBuilder.Entity<PricingList>()
						 .HasKey(p => p.ProductCode);
			

			modelBuilder.Entity<Product>()
			  .HasOne(c => c.Category)
			  .WithMany(p => p.Products)
			  .HasForeignKey(c => c.CategoryID);

			base.OnModelCreating(modelBuilder);
		}
	}
}
