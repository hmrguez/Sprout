using Domain;
using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private static void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new UserId(value));
        
        builder.Property(u => u.CreatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new CreatorId(value));

        builder.Property(u => u.StudentId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StudentId(value));
        
        builder.Property(u => u.Id).ValueGeneratedNever();
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.Email).IsRequired();
    }
}