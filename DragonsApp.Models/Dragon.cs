namespace DragonsApp.Models;

public class Dragon
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset LastModifiedAt { get; set; } = DateTimeOffset.Now;
    public ICollection<History>? Histories { get; set; }
}
