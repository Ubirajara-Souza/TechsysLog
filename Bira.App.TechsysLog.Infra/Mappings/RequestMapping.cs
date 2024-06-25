using Bira.App.TechsysLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bira.App.TechsysLog.Infra.Mappings
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Number)
            .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DateRegister)
                .IsRequired()
                .HasColumnType("timestamp(7)");

            builder.Property(x => x.DataUpdate)
                .HasColumnType("timestamp(7)");

            builder.Property(x => x.DateDeactivation)
                .HasColumnType("timestamp(7)");

            builder.Property(x => x.DateDelivery)
                .IsRequired()
                .HasColumnType("timestamp(7)");

            builder.HasOne(p => p.Address)
                .WithOne(a => a.Request);

            builder.ToTable("Pedidos");
        }
    }
}
