﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(b => b.RoomID)
               .HasColumnName("Room_ID")
               .UseIdentityColumn();

            builder.Property(b => b.StartDate)
              .IsRequired();

            builder.Property(b => b.EndDate)
               .IsRequired();

            builder.Property(b => b.BookingDate)
             .IsRequired();

            builder.Property(b => b.IsActive)
            .IsRequired();

            
            //Звязки 

            //Many to many
            builder.HasMany(s => s.Services)
                .WithMany(c => c.Bookings)
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
