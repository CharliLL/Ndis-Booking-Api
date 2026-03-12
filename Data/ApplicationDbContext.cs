using Microsoft.EntityFrameworkCore;
using NDISBookingApi.Models;

namespace NDISBookingApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProviderService> ProviderServices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User-Provider one-to-one relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Provider)
                .WithOne(p => p.User)
                .HasForeignKey<Provider>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // USer-Booking one-to-many relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Provider-Booking one-to-many relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Provider)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Provider-ProviderService many-to-many relationship
            modelBuilder.Entity<ProviderService>()
                .HasOne(ps => ps.Provider)
                .WithMany(p => p.ProviderServices)
                .HasForeignKey(ps => ps.ProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service-Booking one-to-many relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Service)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Service-ProviderService many-to-many relationship
            modelBuilder.Entity<ProviderService>()
                .HasOne(ps => ps.Service)
                .WithMany(s => s.ProviderServices)
                .HasForeignKey(ps => ps.ServiceId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasMaxLength(20);

            modelBuilder.Entity<Provider>()
                .Property(p => p.Phone)
                .HasMaxLength(50);

            modelBuilder.Entity<Provider>()
                .Property(p => p.Location)
                .HasMaxLength(200);

            modelBuilder.Entity<Service>()
               .Property(s => s.Name)
               .HasMaxLength(100);

            modelBuilder.Entity<Booking>()
               .Property(b => b.Status)
               .HasMaxLength(20);
        }

    }
}
