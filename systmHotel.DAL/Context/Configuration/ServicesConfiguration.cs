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
    internal class ServicesConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(s => s.ServiceID);

            builder.Property(s => s.ServiceID)
               .HasColumnName("Service_ID")
               .UseIdentityColumn();

            builder.Property(s => s.ServiceName)
                .IsRequired();

            builder.Property(s => s.Price)
                .IsRequired();




        }

    }
}
