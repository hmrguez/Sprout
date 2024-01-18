using Domain;
using Domain.Course;
using Domain.Course.ValueObjects;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new CourseId(value));

        builder.Property(c => c.CreatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new CreatorId(value));
        
        // builder.OwnsOne(c => c.Id, id =>
        // {
        //     id.Property(i => i.Value).HasColumnName("Id").IsRequired();
        // });
        //
        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.ThumbnailUrl).IsRequired();
        builder.Property(c => c.Rating).IsRequired();
        builder.HasMany(c => c.Paths);
        builder.HasMany(c => c.Lessons);
        builder.HasMany(c => c.Students);
    }
}