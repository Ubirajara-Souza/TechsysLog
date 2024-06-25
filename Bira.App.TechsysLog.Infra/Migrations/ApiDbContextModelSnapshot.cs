﻿// <auto-generated />
using System;
using Bira.App.TechsysLog.Infra.Repositories.BaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bira.App.TechsysLog.Infra.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bira.App.TechsysLog.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataUpdate")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<DateTime?>("DateDeactivation")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("Bira.App.TechsysLog.Domain.Entities.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataUpdate")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<DateTime?>("DateDeactivation")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("timestamp(7) without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("Bira.App.TechsysLog.Domain.Entities.Address", b =>
                {
                    b.HasOne("Bira.App.TechsysLog.Domain.Entities.Request", "Request")
                        .WithOne("Address")
                        .HasForeignKey("Bira.App.TechsysLog.Domain.Entities.Address", "RequestId")
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Bira.App.TechsysLog.Domain.Entities.Request", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
