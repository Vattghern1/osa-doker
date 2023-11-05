namespace Osa_Lab_Doker.Common.DataTransferObjects;

public class FullNoteDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Content { get; set; }
    public required DateTime DateOfCreation { get; set; }
    public DateTime? DateOfModification { get; set;}
}
