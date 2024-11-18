using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Context.Configuration;
using systmHotel.DAL.Entities;

namespace systmHotel.DAL.Context
{
    public class systHotelContext : DbContext
    {
        public systHotelContext(DbContextOptions options):base(options) { }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }

        //public DbSet<User> Users { get; set; } 

        public DbSet<Admin>? Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new UserConfiguration()); // Реєстрація User
            //modelBuilder.ApplyConfiguration(new ClientConfiguration()); // Реєстрація Client
        }
    }
}
