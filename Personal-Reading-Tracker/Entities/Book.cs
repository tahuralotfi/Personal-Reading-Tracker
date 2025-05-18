namespace Personal_Reading_Tracker.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int? Pages { get; set; }

    public ICollection<ReadingRecord> ReadingRecords { get; set; }
}
