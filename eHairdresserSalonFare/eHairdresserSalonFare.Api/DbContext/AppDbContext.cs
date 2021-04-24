using eHairdresserSalonFare.Api;
using eHairdresserSalonFare.Api.Database;
using eHairdresserSalonFareBugojno.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

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
            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HairdresserSalon>().HasData
            (
                new HairdresserSalon
                {
                    Id = 1,
                    Salon = "Fare barbershop Bugojno",
                    Email = "fare_barber@gmail.com",
                    Phone = "063907678",
                    Address = "Sultan Ahmedova II",
                    Logo = File.ReadAllBytes("Images/logo.jpg")
                }
            );

            modelBuilder.Entity<Role>().HasData
            (
                new Role
                {
                    Id = 1,
                    Description = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Description = "Client"
                }
            );

            modelBuilder.Entity<Notification>().HasData
            (
                new Notification
                {
                    Id = 1,
                    Title = "Neradni dani",
                    Text = "Povodom dana državnosti 25.11.2021. Vaš frizerski salon Fare neće raditi.",
                    NotificationDate = new DateTime(2021, 11, 24),
                    HairdresserSalonId=1
                },
                new Notification
                {
                    Id = 2,
                    Title = "Bajramska čestitka",
                    Text = "Puno zdravlja, sreće i uspjeha u životu povodom predstojećih praznika uz riječi Bajram Šerif Mubarek Olsun želi Vam Vaš frizerski salon Fare.",
                    NotificationDate = new DateTime(2021, 08, 14),
                    HairdresserSalonId=1
                }
            );

            modelBuilder.Entity<Sponsor>().HasData
            (
                new Sponsor
                {
                    Id = 1,
                    SponsorName = "Pizzeria AKO",
                    HairdresserSalonId = 1,
                    About = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Email = "ako_bug@gmail.com",
                    Phone = "033221212",
                    Logo = File.ReadAllBytes("Images/akoo.jpg")
                },
                new Sponsor
                {
                    Id = 2,
                    SponsorName = "Caffe TWO",
                    HairdresserSalonId = 1,
                    About = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Email = "two@gmail.com",
                    Phone = "033224982",
                    Logo = File.ReadAllBytes("Images/two.jpg")
                }
            );

            modelBuilder.Entity<Associate>().HasData
            (
                new Associate
                {
                    Id = 1,
                    AssociateName = "DM Bugojno",
                    Email = "dm@gmail.com",
                    Phone = "030226711",
                    HairdresserSalonId = 1
                },
                new Associate
                {
                    Id = 2,
                    AssociateName = "Frizerland BiH",
                    Email = "frizerland_bih@gmail.com",
                    Phone = "0302219801",
                    HairdresserSalonId = 1
                }
            );

            User admin = new User
            {
                Id = 1,
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                Phone = "030222111",
                Username = "admin",
                Image = File.ReadAllBytes("Images/default-pic.png"),
                RoleId = 1
            };
            admin.PasswordSalt = HashGenerator.GenerateSalt();
            admin.PasswordHash = HashGenerator.GenerateHash(admin.PasswordSalt, "Admin1234!");

            User user1 = new User
            {
                Id = 2,
                FirstName = "User1",
                LastName = "User1",
                Email = "user1@gmail.com",
                Phone = "030222112",
                Username = "user1",
                Image = File.ReadAllBytes("Images/default-pic.png"),
                RoleId = 2
            };
            user1.PasswordSalt = HashGenerator.GenerateSalt();
            user1.PasswordHash = HashGenerator.GenerateHash(user1.PasswordSalt, "User11234!");

            User user2 = new User
            {
                Id = 3,
                FirstName = "User2",
                LastName = "User2",
                Email = "user2@gmail.com",
                Phone = "030222113",
                Username = "user2",
                Image = File.ReadAllBytes("Images/default-pic.png"),
                RoleId = 2
            };
            user2.PasswordSalt = HashGenerator.GenerateSalt();
            user2.PasswordHash = HashGenerator.GenerateHash(user2.PasswordSalt, "User21234!");

            User user3 = new User
            {
                Id = 4,
                FirstName = "User3",
                LastName = "User3",
                Email = "user3@gmail.com",
                Phone = "030222114",
                Username = "user3",
                Image = File.ReadAllBytes("Images/default-pic.png"),
                RoleId = 2
            };
            user3.PasswordSalt = HashGenerator.GenerateSalt();
            user3.PasswordHash = HashGenerator.GenerateHash(user3.PasswordSalt, "User31234!");

            User user4 = new User
            {
                Id = 5,
                FirstName = "User4",
                LastName = "User4",
                Email = "user4@gmail.com",
                Phone = "030222115",
                Username = "user4",
                Image = File.ReadAllBytes("Images/default-pic.png"),
                RoleId = 2
            };
            user4.PasswordSalt = HashGenerator.GenerateSalt();
            user4.PasswordHash = HashGenerator.GenerateHash(user4.PasswordSalt, "User41234!");
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<User>().HasData(user1);
            modelBuilder.Entity<User>().HasData(user2);
            modelBuilder.Entity<User>().HasData(user3);
            modelBuilder.Entity<User>().HasData(user4);

            modelBuilder.Entity<Hairdresser>().HasData
            (
                new Hairdresser
                {
                    Id = 1,
                    FirstName = "Faruk",
                    LastName = "Omanović",
                    BirthDate = new DateTime(1990, 02, 24),
                    PersonalIdentificationNumber = "1234567891876",
                    Phone = "062442221",
                    Email = "fare@gmail.com",
                    Salary = 1500,
                    Image = File.ReadAllBytes("Images/Frizer1.jpg"),
                    HairdresserSalonId = 1,
                    Available = true
                },
                new Hairdresser
                {
                    Id = 2,
                    FirstName = "Kenan",
                    LastName = "Mustafica",
                    BirthDate = new DateTime(1995, 02, 17),
                    PersonalIdentificationNumber = "1234567891316",
                    Phone = "062442233",
                    Email = "keno@gmail.com",
                    Salary = 1300,
                    Image = File.ReadAllBytes("Images/frizer2.jpg"),
                    HairdresserSalonId = 1,
                    Available = true
                },
                new Hairdresser
                {
                    Id = 3,
                    FirstName = "Sulejman",
                    LastName = "Mehić",
                    BirthDate = new DateTime(1990, 05, 24),
                    PersonalIdentificationNumber = "1234017891876",
                    Phone = "062442443",
                    Email = "suke@gmail.com",
                    Salary = 1000,
                    Image = File.ReadAllBytes("Images/frizer3.jpg"),
                    HairdresserSalonId = 1,
                    Available = true
                },
                new Hairdresser
                {
                    Id = 4,
                    FirstName = "Emir",
                    LastName = "Crnkić",
                    BirthDate = new DateTime(1999, 09, 04),
                    PersonalIdentificationNumber = "3214567891876",
                    Phone = "0624412221",
                    Email = "emy@gmail.com",
                    Salary = 700,
                    Image = File.ReadAllBytes("Images/emir-frize.jpg"),
                    HairdresserSalonId = 1,
                    Available = true
                }
            );

            modelBuilder.Entity<Hairstyle>().HasData
           (
               new Hairstyle
               {
                   Id = 1,
                   HairstyleName = "Skin fade",
                   Description = "A skin fade is achieved by cutting the hair shorter and shorter as it moves toward the neck. Whereas some haircuts require the hair to be the same length all around the head," +
                   "skin fade haircuts demand the hair to be cut at decreasing lengths.",
                   Price = 7,
                   DurationOfProduction = 20,
                   Image = File.ReadAllBytes("Images/skin fade.jpg")
               },
               new Hairstyle
               {
                   Id = 2,
                   HairstyleName = "Short hairstyle",
                   Description = "Short hair refers to any haircut with little length. It may vary from above the ears to below the chin. If a man's hair reaches the chin, it may not be considered short. For a woman, however, short varies from close-cropped to just above the shoulders.",
                   Price = 5,
                   DurationOfProduction = 15,
                   Image = File.ReadAllBytes("Images/short-hairstyle.jpg")
               },
               new Hairstyle
               {
                   Id = 3,
                   HairstyleName = "Medium hairstyle",
                   Description = "Medium length – also known as mid-length hair – is having a moment. ... In general, a medium-cut sees the ends of your hair at your collarbones or your shoulder blades. This type of hairstyle works with all hair types – from straight to wavy, curly, and natural – as well as all hair textures.",
                   Price = 10,
                   DurationOfProduction = 20,
                   Image = File.ReadAllBytes("Images/medium-hairstyle.jpg")
               },
               new Hairstyle
               {
                   Id = 4,
                   HairstyleName = "Beard trimming",
                   Description = "The best way to trim your beard is to start with the longest hair length and bring it down gradually. Set your beard trimmer to its longest setting and trim your beard all over. Go against the direction of hair growth to remove excess bulk. Repeat using shorter trim settings until you're happy with the length.",
                   Price = 3,
                   DurationOfProduction = 5,
                   Image = File.ReadAllBytes("Images/beard-trimming.jpg")
               },
               new Hairstyle
               {
                   Id = 5,
                   HairstyleName = "Hair coloring",
                   Description = "Long hair affords the wearer far more variety than shorter styles. You can wear your hair straight and smooth, wild and wavy, half up, half down, pinned, in braids – the options are endless. This versatility is attractive to men. Experimenting with your style demonstrates adventure and excitement.",
                   Price = 20,
                   DurationOfProduction = 40,
                   Image = File.ReadAllBytes("Images/hairstyle coloring.jpg")
               },
               new Hairstyle
               {
                   Id = 6,
                   HairstyleName = "Long hairstyle",
                   Description = "Hair coloring, or hair dyeing, is the practice of changing the hair color. The main reasons for this are cosmetic: to cover gray or white hair, to change to a color regarded as more fashionable or desirable, or to restore the original hair color after it has been discolored by hairdressing processes or sun bleaching.",
                   Price = 12,
                   DurationOfProduction = 30,
                   Image = File.ReadAllBytes("Images/long-hairstyle.jpg")
               }
           );

            modelBuilder.Entity<HairdresserHairstyle>().HasData
            (
               new HairdresserHairstyle
               {
                   HairdresserId = 1,
                   HairstyleId = 1
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 1,
                   HairstyleId = 2
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 1,
                   HairstyleId = 3
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 1,
                   HairstyleId = 4
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 1,
                   HairstyleId = 6
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 2,
                   HairstyleId = 2
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 2,
                   HairstyleId = 1
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 2,
                   HairstyleId = 5
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 2,
                   HairstyleId = 4
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 3,
                   HairstyleId = 1
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 3,
                   HairstyleId = 2
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 3,
                   HairstyleId = 4
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 4,
                   HairstyleId = 1
               }, new HairdresserHairstyle
               {
                   HairdresserId = 4,
                   HairstyleId = 2
               }, new HairdresserHairstyle
               {
                   HairdresserId = 4,
                   HairstyleId = 3
               },
               new HairdresserHairstyle
               {
                   HairdresserId = 4,
                   HairstyleId = 4
               }
            );

            modelBuilder.Entity<Comment>().HasData
           (
               new Comment
               {
                   Id = 1,
                   Text = "Sve pohvale za Faruka.",
                   UserId = 2,
                   Date = new DateTime(2021, 04, 17, 10, 30, 00)
               },
               new Comment
               {
                   Id = 2,
                   Text = "Odlična usluga i pristup frizera, samo malo prevruće u salonu :)",
                   UserId = 3,
                   Date = new DateTime(2021, 04, 10, 14, 10, 00)
               }
           );

            modelBuilder.Entity<Booking>().HasData
            (
                 new Booking
                 {
                     Id = 1,
                     UserId = 2,
                     HairdresserId = 1,
                     HairstyleId = 1,
                     StartDate = new DateTime(2021, 04, 05, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 05, 09, 20, 00)
                 },
                 new Booking
                 {
                     Id = 2,
                     UserId = 2,
                     HairdresserId = 2,
                     HairstyleId = 2,
                     StartDate = new DateTime(2021, 04, 06, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 06, 09, 20, 00)
                 },
                 new Booking
                 {
                     Id = 3,
                     UserId = 4,
                     HairdresserId = 3,
                     HairstyleId = 4,
                     StartDate = new DateTime(2021, 04, 15, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 15, 09, 20, 00)
                 },
                 new Booking
                 {
                     Id = 4,
                     UserId = 2,
                     HairdresserId = 2,
                     HairstyleId = 5,
                     StartDate = new DateTime(2021, 04, 05, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 05, 09, 20, 00)
                 },
                 new Booking
                 {
                     Id = 5,
                     UserId = 4,
                     HairdresserId = 4,
                     HairstyleId = 4,
                     StartDate = new DateTime(2021, 04, 03, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 03, 09, 20, 00)
                 },
                 new Booking
                 {
                     Id = 6,
                     UserId = 3,
                     HairdresserId = 2,
                     HairstyleId = 6,
                     StartDate = new DateTime(2021, 04, 01, 09, 00, 00),
                     EndDate = new DateTime(2021, 04, 01, 09, 20, 00)
                 }
            );

            modelBuilder.Entity<Payment>().HasData
            (
                 new Payment
                 {
                     Id = 1,
                     PaymentDate = new DateTime(2021, 04, 08),
                     Amount = 7,
                     BankCardNumber = "12035627651",
                     UserId = 2
                 },
                 new Payment
                 {
                     Id = 2,
                     PaymentDate = new DateTime(2021, 04, 10),
                     Amount = 20,
                     BankCardNumber = "12035609651",
                     UserId = 3
                 },
                 new Payment
                 {
                     Id = 3,
                     PaymentDate = new DateTime(2021, 03, 04),
                     Amount = 7,
                     BankCardNumber = "12035627671",
                     UserId = 3
                 },
                 new Payment
                 {
                     Id = 4,
                     PaymentDate = new DateTime(2021, 04, 10),
                     Amount = 10,
                     BankCardNumber = "12035627622",
                     UserId = 2
                 },
                 new Payment
                 {
                     Id = 5,
                     PaymentDate = new DateTime(2021, 04, 14),
                     Amount = 3,
                     BankCardNumber = "12035627601",
                     UserId = 4
                 }
            );

            modelBuilder.Entity<Rating>().HasData
            (
                 new Rating
                 {
                     Id = 1,
                     UserId = 2,
                     HairdresserId = 1,
                     Rate = 5
                 },
                 new Rating
                 {
                     Id = 2,
                     UserId = 2,
                     HairdresserId = 1,
                     Rate = 5
                 },
                 new Rating
                 {
                     Id = 3,
                     UserId = 4,
                     HairdresserId = 2,
                     Rate = 4
                 },
                 new Rating
                 {
                     Id = 4,
                     UserId = 4,
                     HairdresserId = 1,
                     Rate = 4
                 },
                 new Rating
                 {
                     Id = 5,
                     UserId = 3,
                     HairdresserId = 3,
                     Rate = 5
                 },
                 new Rating
                 {
                     Id = 6,
                     UserId = 3,
                     HairdresserId = 2,
                     Rate = 5
                 }
            );
        }
    }
}
