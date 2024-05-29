using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Infrastructure.Data.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder
            .HasKey(mi => mi.Id);
        builder
            .Property(mi => mi.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(mi => mi.Description)
            .HasMaxLength(500);
        builder
            .Property(mi => mi.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        //builder
        //    .Property(mi => mi.Price)
        //    .IsRequired();

        builder.HasOne(mi => mi.Menu)
            .WithMany(m => m.Items)
            .HasForeignKey(mi => mi.MenuId);

        builder.ToTable("MenuItems");
    }
}