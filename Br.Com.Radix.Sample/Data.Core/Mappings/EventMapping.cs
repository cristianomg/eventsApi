using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mappings
{
    public sealed class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(nameof(Event), "core");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Region)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SensorName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Timestamp)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(EventStatus.Erro);

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

        }
    }
}
