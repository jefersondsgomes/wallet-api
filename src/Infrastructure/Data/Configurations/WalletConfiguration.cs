using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable("wallets");

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
            .Property(p => p.Balance)
            .HasColumnName("balance")
            .HasDefaultValue(0)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(p => p.Transactions)
            .WithOne(p => p.Wallet)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
