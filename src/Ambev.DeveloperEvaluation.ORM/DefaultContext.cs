using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class DefaultContext : DbContext
    {
        // DbSet for Users
        public DbSet<User> Users { get; set; }

        // DbSet for Sales
        public DbSet<Sale> Sales { get; set; }

        // DbSet for SaleItems
        public DbSet<SaleItem> SaleItems { get; set; }

        // DbSet for Customers
        public DbSet<Customer> Customers { get; set; }

        // DbSet for Branches
        public DbSet<Branch> Branches { get; set; }

        /// <summary>
        /// Initializes a new instance of the DefaultContext.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configures the model creation for the database.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure relationships and constraints
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey(si => si.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Branch)
                .WithMany()
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure SaleItem entity
            modelBuilder.Entity<SaleItem>()
                .Property(si => si.TotalItemAmount)
                .HasComputedColumnSql("[Quantity] * [UnitPrice] - [Discount]", stored: true);  // Computed column

            // Configure Customer entity
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Configure Branch entity
            modelBuilder.Entity<Branch>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Branch>()
                .Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Factory for creating DefaultContext instances at design time.
    /// </summary>
    public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        /// <summary>
        /// Creates a new instance of DefaultContext.
        /// </summary>
        /// <param name="args">Arguments passed to the factory.</param>
        /// <returns>A new instance of DefaultContext.</returns>
        public DefaultContext CreateDbContext(string[] args)
        {
            // Load configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configure DbContextOptions
            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Use PostgreSQL as the database provider
            builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
            );

            // Return a new instance of DefaultContext
            return new DefaultContext(builder.Options);
        }
    }
}
