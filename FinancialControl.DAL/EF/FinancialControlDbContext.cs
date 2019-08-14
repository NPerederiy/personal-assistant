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
            modelBuilder.AddFinControlEntities();
            modelBuilder.AddFinControlSeedData();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}