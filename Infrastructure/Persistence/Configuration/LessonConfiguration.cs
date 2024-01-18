using Domain;
using Domain.Course.Entities;
using Domain.Course.ValueObjects;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value, 
                value => new LessonId(value));
        
        builder.Property(l => l.CourseId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value, 
                value => new CourseId(value));
        
        builder.Property(l => l.Title).IsRequired();
        builder.Property(l => l.Description).IsRequired();
        builder.Property(l => l.VideoUrl).IsRequired();
        builder.Property(l => l.ThumbnailUrl).IsRequired();
        builder.Property(l => l.Order).IsRequired();
        builder.Property(l => l.Rating).IsRequired();

        // builder.HasOne(l => l.CourseId);
        // builder.OwnsOne(c => c.CourseId, id =>
        // {
        //     id.Property(i => i.Value).HasColumnName("CourseId").IsRequired();
        // });
        
        
        builder.HasMany(l => l.Students);
    }
}