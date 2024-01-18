using Domain;
using Domain.User.Entities;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new StudentId(value));
        
        builder.Property(c => c.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new UserId(value));
        
        builder.HasMany(s => s.Lessons);
    }
}