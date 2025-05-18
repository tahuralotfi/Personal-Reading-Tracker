namespace Personal_Reading_Tracker.Entities;

public class ReadingRecord
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }

    public ReadingStatus Status { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Rating { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }
}
