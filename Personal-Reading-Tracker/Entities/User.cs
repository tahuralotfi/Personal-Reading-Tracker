namespace Personal_Reading_Tracker.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Email { get; set; }

    public ICollection<ReadingRecord> ReadingRecords { get; set; }
}
