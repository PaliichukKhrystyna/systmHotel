using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systmHotel.DAL.Entities;

namespace systmHotel.DAL.Context.Configuration
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(b => b.BookingID);

            builder.Property(b => b.BookingID)
                .HasColumnName("Booking_Id")
                .UseIdentityColumn();

            builder.Property(b => b.ClientID)
                .IsRequired()
                .HasColumnName("Client_Id");



            //Звязки 

            //Many to many
            builder.HasMany(b => b.Services)
                    .WithMany(s => s.Bookings)
                    .UsingEntity(j => j.ToTable("BookingServices"));


            //one to many
            builder.HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientID);


            //one to many
            builder.HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomID);

        }
    }
}
