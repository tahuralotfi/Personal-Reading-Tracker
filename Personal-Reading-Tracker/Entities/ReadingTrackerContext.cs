using Microsoft.EntityFrameworkCore;

namespace Personal_Reading_Tracker.Entities;

public sealed class ReadingTrackerContext : DbContext
{
    public ReadingTrackerContext(DbContextOptions<ReadingTrackerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<ReadingRecord> ReadingRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}
