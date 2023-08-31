
using Microsoft.EntityFrameworkCore;
using Application.Entities;
using Application;

namespace Application
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products", SchemaNames.ExampleSchemaName);
            modelBuilder.Entity<Category>().ToTable("Categories", SchemaNames.ExampleSchemaName);

        }
    }
}

