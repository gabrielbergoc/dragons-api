namespace DragonsApp.Models;

public class History
{
    public int Id { get; set; }
    public int DragonId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Dragon? Dragon { get; set; }
}
