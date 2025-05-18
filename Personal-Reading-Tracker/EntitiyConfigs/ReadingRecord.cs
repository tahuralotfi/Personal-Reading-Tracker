using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal_Reading_Tracker.Entities;

namespace Personal_Reading_Tracker.EntitiyConfigs;

public class ReadingRecordConfig : IEntityTypeConfiguration<ReadingRecord>
{
    public void Configure(EntityTypeBuilder<ReadingRecord> builder)
    {
        // Configure primary key with identity (auto-increment)
        builder.Property(r => r.Id)
               .ValueGeneratedOnAdd();

        // Required foreign key to User
        builder.Property(r => r.UserId)
               .IsRequired();

        // Required foreign key to Book
        builder.Property(r => r.BookId)
               .IsRequired();

        // Required reading status (e.g., ToRead, Reading, Finished)
        builder.Property(r => r.Status)
               .IsRequired();

        // Optional fields: reading dates and rating
        builder.Property(r => r.StartDate)
               .IsRequired(false);

        builder.Property(r => r.EndDate)
               .IsRequired(false);

        builder.Property(r => r.Rating)
               .IsRequired(false);

        // Optional notes field (max 1000 characters)
        builder.Property(r => r.Notes)
               .IsRequired(false)
               .HasMaxLength(1000);

        // Index for efficient queries by user
        builder.HasIndex(r => r.UserId);

        // Index for efficient queries by book
        builder.HasIndex(r => r.BookId);

        // Composite index for filtering records by user and reading status
        builder.HasIndex(r => new { r.UserId, r.Status });

        // Define relationship to User with cascade delete
        builder.HasOne(r => r.User)
               .WithMany(u => u.ReadingRecords)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Define relationship to Book with cascade delete
        builder.HasOne(r => r.Book)
               .WithMany(b => b.ReadingRecords)
               .HasForeignKey(r => r.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
