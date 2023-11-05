using Microsoft.AspNetCore.Mvc;
using Osa_Lab_Doker.Common.DataTransferObjects;

namespace Osa_Lab_Doker.Common.Interfaces;

public interface INoteService
{
    public Task<Guid> CreateNote(CreateEditNoteDTO noteDTO);
    public Task DeleteNote(Guid noteId);
    public Task EditNote(Guid noteId, CreateEditNoteDTO noteDTO);
    public Task<List<LessNoteDTO>> GetAllNotes();
    public Task<FullNoteDTO> GetNote(Guid noteId);

}
