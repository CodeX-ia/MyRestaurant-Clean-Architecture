﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Infrastructure.Data.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(m => m.Description)
            .HasMaxLength(500);

        builder.HasMany(m => m.Items)
            .WithOne(mi => mi.Menu)
            .HasForeignKey(mi => mi.MenuId);

        builder.ToTable("Menus");
    }
}
