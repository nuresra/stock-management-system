namespace StockManagementSystem.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
        .HasKey(p => p.Id);  // Id alanının birincil anahtar olduğundan emin olun

            // Sabit kullanıcı ekleme
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "12345" } // Şifreyi güvenli şekilde hashleyebilirsin
            );
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Debt> Debts { get; set; }
    }


}
