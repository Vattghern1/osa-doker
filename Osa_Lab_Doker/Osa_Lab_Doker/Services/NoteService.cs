using Microsoft.EntityFrameworkCore;
using Osa_Lab_Doker.Common.DataTransferObjects;
using Osa_Lab_Doker.Common.Interfaces;
using Osa_Lab_Doker.Data;
using Osa_Lab_Doker.Data.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Osa_Lab_Doker.Services;

public class NoteService : INoteService
{

    private readonly ILogger<NoteService> _logger; 
    private readonly BackendDbContext _dbContext;

    public NoteService(ILogger<NoteService> logger, BackendDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateNote(CreateEditNoteDTO noteDTO)
    {
        Note newNote = new()
        {
            Name = noteDTO.Title,
            Content = noteDTO.Content,
            DateOfCreation = DateTime.UtcNow,
        };

        await _dbContext.AddAsync(newNote);
        await _dbContext.SaveChangesAsync();

        return newNote.Id;
    }

    public async Task DeleteNote(Guid noteId)
    {
        var Note = await _dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id ==  noteId) ?? throw new Exception();
        _dbContext.Remove(Note);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditNote(Guid noteId, CreateEditNoteDTO noteDTO)
    {
        var Note = await _dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId) ?? throw new Exception();
        Note.Content = noteDTO.Content;
        Note.Name = noteDTO.Title;
        Note.DateOfModification = DateTime.UtcNow;

        _dbContext.Update(Note);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<LessNoteDTO>> GetAllNotes()
    {
        var Notes = await _dbContext.Notes.ToListAsync();

        var shortNotes = Notes.Select(x => new LessNoteDTO
        {
            Id = x.Id,
            Title = x.Name
        }).ToList();

        return shortNotes;
    }

    public async Task<FullNoteDTO> GetNote(Guid noteId)
    {
        var Note = await _dbContext.Notes
            .FirstOrDefaultAsync(n => n.Id == noteId) ?? throw new Exception();

        var response = new FullNoteDTO
        {
            Id = Note.Id,
            Name = Note.Name,
            Content = Note.Content,
            DateOfCreation = Note.DateOfCreation,
            DateOfModification = Note.DateOfModification
        };

        return response;
    }
}
