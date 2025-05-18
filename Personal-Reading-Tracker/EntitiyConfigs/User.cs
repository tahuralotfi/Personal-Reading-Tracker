using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal_Reading_Tracker.Entities;

namespace Personal_Reading_Tracker.EntitiyConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Identity column (auto-increment)
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            // Username: Required, Max 50 chars, Unique
            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasIndex(u => u.Username)
                   .IsUnique();

            // PasswordHash: Required, Max 256 chars
            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(256);

            // Email: Optional, Max 100 chars, Unique if not null
            builder.Property(u => u.Email)
                   .HasMaxLength(100);
            builder.HasIndex(u => u.Email)
                   .IsUnique()
                   .HasFilter("[Email] IS NOT NULL"); // SQL Server only

            // Relationship: User has many ReadingRecords
            builder.HasMany(u => u.ReadingRecords)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
