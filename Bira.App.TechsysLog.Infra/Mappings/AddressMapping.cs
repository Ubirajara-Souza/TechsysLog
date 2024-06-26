﻿using Bira.App.TechsysLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bira.App.TechsysLog.Infra.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(a => a.Complement)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(x => x.DateRegister)
                .IsRequired()
                .HasColumnType("timestamp(7)");

            builder.Property(x => x.DataUpdate)
                .HasColumnType("timestamp(7)");

            builder.Property(x => x.DateDeactivation)
                .HasColumnType("timestamp(7)");

            builder.ToTable("Enderecos");
        }
    }
}
