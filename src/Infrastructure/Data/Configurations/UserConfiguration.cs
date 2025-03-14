using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private static readonly ValueConverter<Email, string> _emailConverter = new(
        email => email.Address!,
        address => new Email(address));

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

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
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(60)")
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(60)")
            .HasConversion(_emailConverter)
            .IsRequired();

        builder
            .Property(p => p.UserName)
            .HasColumnName("user_name")
            .HasColumnType("VARCHAR(30)")
            .IsRequired();

        builder
            .Property(p => p.Password)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(30)")
            .IsRequired();

        builder
            .HasIndex(i => i.Email)
            .HasDatabaseName("idx_users_email");
    }
}
