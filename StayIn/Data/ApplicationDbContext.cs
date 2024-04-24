using Microsoft.EntityFrameworkCore;
using StayInAPI.Models;

namespace StayInAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet <Restaurant> Restaurant { get; set; }
        public DbSet <Adress> Adress { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Customer_Adress> Customer_Adress { get; set;}
        public DbSet<Delivery_Guy> Delivery_Guy { get; set; }
        public DbSet<Menu_Item> Menu_Item { get; set; } 
        public DbSet<Order_Menu_Item> Order_Menu_Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(a => a.OrderID);
                entity.Property(a => a.Number).IsRequired();
                entity.Property(a => a.Date).IsRequired();

                entity.HasOne(a => a.Customer)
                .WithMany(p => p.Order)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Restaurant)
                .WithMany(p => p.Order)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Delivery_Guy)
                .WithMany(p => p.Order)
                .HasForeignKey(a => a.DeliveryGuyId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Customer_Adress)
                .WithMany(p => p.Order)
                .HasForeignKey(a => a.CustomerAdressId)
                .OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(a => a.RestaurantId);
                entity.Property(a => a.RestaurantName).IsRequired();
                entity.Property(a => a.RestaurantName).IsRequired();

                entity.HasOne(a => a.Adress)
                .WithMany(p => p.Restaurant)
                .HasForeignKey(a => a.AdressId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.HasKey(a => a.AdressId);
                entity.Property(a => a.StreetNumber).IsRequired();
                entity.Property(a => a.ZIP).IsRequired();
                entity.Property(a => a.City).IsRequired();
                entity.Property(a => a.Region).IsRequired();

                entity.HasOne(a => a.Country)
                .WithMany(p => p.Adress)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(a => a.CountryId);
                entity.Property(a=>a.Name).IsRequired();

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(a => a.CustomerId);
                entity.Property(a => a.FirstName).IsRequired();
                entity.Property(a => a.LastName).IsRequired();
            });

            modelBuilder.Entity<Customer_Adress>(entity =>
            {
                entity.HasKey(a => a.CaId);

                entity.HasOne(a => a.Customer)
                .WithMany(p => p.Customer_Adress)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Adress)
                .WithMany(p => p.Customer_Adress)
                .HasForeignKey(a => a.AdressId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Delivery_Guy>(entity =>
            {
                entity.HasKey(a => a.DeliveryGuyId);
                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.CNP).IsRequired();
                entity.Property(a => a.Number).IsRequired();

            });

            modelBuilder.Entity<Menu_Item>(entity =>
            {
                entity.HasKey(a => a.MenuItemId);
                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.Price).IsRequired();

                entity.HasOne(a => a.Restaurant)
                .WithMany(p => p.Menu_Item)
                .HasForeignKey(a => a.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Order_Menu_Item>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.QtyOrdered).IsRequired();

                entity.HasOne(a => a.Order)
                .WithMany(p => p.Order_Menu_Item)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Menu_Item)
                .WithMany(p => p.Order_Menu_Item)
                .HasForeignKey(a => a.MenuItemId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
