using Domain;
using Domain.User.Entities;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CreatorConfiguration : IEntityTypeConfiguration<Creator>
{
    public void Configure(EntityTypeBuilder<Creator> builder)
    {
        builder.ToTable("Creators");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new CreatorId(value));
        
        builder.Property(c => c.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new UserId(value));
        
        builder.HasMany(s => s.Courses);
    }
}