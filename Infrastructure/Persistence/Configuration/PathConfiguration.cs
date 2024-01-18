using Domain.Course.ValueObjects;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path = Domain.Course.Entities.Path;

namespace Infrastructure.Persistence.Configuration;

public class PathConfiguration : IEntityTypeConfiguration<Path>
{
    public void Configure(EntityTypeBuilder<Path> builder)
    {
        builder.ToTable("Paths");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new PathId(value));
        
        builder.Property(p => p.CreatorId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new CreatorId(value));
        
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.ThumbnailUrl).IsRequired();
        builder.Property(p => p.Rating).IsRequired();
        builder.HasMany(p => p.Courses);
        builder.HasMany(p => p.Students);
    }
}