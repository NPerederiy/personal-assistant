using FinancialControl.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.DAL.EF
{
    public class FinancialControlDbContext : DbContext
    {
        public FinancialControlDbContext() : base()
        {
        }

        public FinancialControlDbContext(DbContextOptions<FinancialControlDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Server=FRACTAL-LAPTOP;Database=FinancialControl;User ID=sa;Password=A4irj3449;Pooling=true;Min Pool Size=5;Max Pool Size=500;Connect Timeout=30;";
        //    optionsBuilder.UseLazyLoadingProxies()
        //                  .UseSqlServer(connectionString, x => x.MigrationsAssembly("FinancialControl.DAL"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);

                b.HasMany(u => u.Categories)
                 .WithOne(c => c.User)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.Name)
                 .IsRequired();

                b.HasMany(c => c.Groups)
                 .WithOne(g => g.Category)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(c => c.Operations)
                 .WithOne(o => o.Category)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Group>(b => 
            {
                b.HasKey(g => g.Id);

                b.Property(g => g.Name)
                 .IsRequired();

                b.HasMany(g => g.Operations)
                 .WithOne(o => o.Group)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Operation>(b => 
            {
                b.HasKey(o => o.Id);

                b.Property(o => o.Name)
                .IsRequired();

                b.Property(o => o.Cost)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
            });                

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}