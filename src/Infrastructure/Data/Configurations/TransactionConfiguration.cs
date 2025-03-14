using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("id");

        builder
            .Property(p => p.Created)
            .HasColumnName("created")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Amount)
            .HasColumnName("amount")
            .HasDefaultValue(0)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("VARCHAR(60)")
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Type)
            .HasColumnName("type")
            .HasConversion<string>();
    }
}
