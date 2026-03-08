using KrishiBazaarProject.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace KrishiBazaarProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<PrimaryHub> PrimaryHubs { get; set; }
        public DbSet<SecondaryHub> SecondaryHubs { get; set; }
        public DbSet<UserMessages> Messages { get; set; }
        public DbSet<RatingAndReview> Reviews { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecondaryHub>()
                        .HasOne(sh => sh.PrimaryHub)
                        .WithMany(ph => ph.SecondaryHubs)
                        .HasForeignKey(sh => sh.PrimaryHubID)
                        .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserMessages>()
                .HasOne(um => um.Sender)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(um => um.SenderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserMessages>()
                .HasOne(um => um.Receiver)
                .WithMany(u => u.MessagesReceived)
                .HasForeignKey(um => um.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
