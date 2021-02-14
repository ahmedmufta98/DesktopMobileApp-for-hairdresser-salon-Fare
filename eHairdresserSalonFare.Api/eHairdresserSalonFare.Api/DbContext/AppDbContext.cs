using eHairdresserSalonFare.Api.Database;
using eHairdresserSalonFareBugojno.Database;
using Microsoft.EntityFrameworkCore;

namespace eHairdresserSalonFareBugojno.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<HairdresserSalon> HairdresserSalons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Hairstyle> Hairstyles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<HairdresserHairstyle> HairdresserHairstyles { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<HairdresserHairstyle>().HasKey(h => new { h.HairdresserId, h.HairstyleId });
        }
    }
}
