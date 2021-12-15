using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem.Models
{
    public partial class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=.;Database=UserDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AccountBalance)
                    .IsRequired()
                    .HasColumnName("AccountBalance")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
