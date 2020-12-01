using Microsoft.EntityFrameworkCore;


namespace ProductManagerV_EF.Model
{
    class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SAIID-PC\SQL19; Database=ProductManagerV-EF; Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<CategorySubCategory> CategorySubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(c => new { c.ProductId, c.CategoryId });

            modelBuilder.Entity<CategorySubCategory>().HasKey(c => new { c.CategoryId, c.SubCategoryId });
        }
    }
}
