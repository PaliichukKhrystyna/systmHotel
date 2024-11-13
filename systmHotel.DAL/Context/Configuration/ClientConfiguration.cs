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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c=>c.ClientID);

            builder.Property(c =>c.ClientID)
               .HasColumnName("Client_ID")
               .UseIdentityColumn();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Surname)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
               .IsRequired();

            builder.Property(c => c.Status)
              .IsRequired();

        }
    }
}
