namespace Osa_Lab_Doker.Data.Entities;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string? Content { get; set; }
    public required DateTime DateOfCreation { get; set; }
    public DateTime? DateOfModification { get; set; }
}
