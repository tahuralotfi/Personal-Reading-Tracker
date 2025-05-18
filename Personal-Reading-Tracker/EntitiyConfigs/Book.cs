using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal_Reading_Tracker.Entities;

namespace Personal_Reading_Tracker.EntitiyConfigs;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
    {
        // Identity column (auto-increment)
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // Title: Required, Max 200 chars
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(256);

        // Author: Required, Max 100 chars
        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(256);

        // Pages: Optional
        builder.Property(b => b.Pages)
            .IsRequired(false);

        // Composite index on Title and Author
        builder.HasIndex(b => new { b.Title, b.Author });

        // Relationship: Book has many ReadingRecords
        builder.HasMany(b => b.ReadingRecords)
            .WithOne(r => r.Book)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
