using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Domain.ValueObjects;

namespace MyRestaurant.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100)
               .HasConversion(new EmailConverter());

        builder.Property(u => u.PasswordHash)
               .IsRequired();

        // Configuring EF Core to use the constructor
        //builder.HasData(
        //   new User(Guid.NewGuid(), "admin", "admin@example.com", "hashedpassword")
        //);
    }
}
