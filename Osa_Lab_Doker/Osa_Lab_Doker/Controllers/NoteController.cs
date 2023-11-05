using Microsoft.AspNetCore.Mvc;
using Osa_Lab_Doker.Common.DataTransferObjects;
using Osa_Lab_Doker.Common.Interfaces;
using Osa_Lab_Doker.Data.Entities;

namespace Osa_Lab_Doker.Controllers;

[ApiController]
[Route("api/note")]
public class NoteController : ControllerBase
{
    private readonly ILogger<NoteController> _logger;
    private readonly INoteService _noteService;

    public NoteController(ILogger<NoteController> logger, INoteService noteService)
    {
        _logger = logger;
        _noteService = noteService; 
    }

    /// <summary>
    /// Create note
    /// </summary>
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateEditNoteDTO noteDTO)
    {

        return Ok(await _noteService.CreateNote(noteDTO));
    }

    /// <summary>
    /// Delete note
    /// </summary>
    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<Guid>> DeleteNote([FromQuery] Guid noteId)
    {
        await _noteService.DeleteNote(noteId);
        return Ok();
    }

    /// <summary>
    /// Edit note
    /// </summary>
    [HttpPut]
    [Route("edit")]
    public async Task<ActionResult<Guid>> EditNote([FromQuery] Guid noteId, [FromBody] CreateEditNoteDTO noteDTO)
    {
        await _noteService.EditNote(noteId, noteDTO);
        return Ok();
    }

    /// <summary>
    /// Get all notes
    /// </summary>
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<List<LessNoteDTO>>> GetAllNotes()
    {

        return Ok(await _noteService.GetAllNotes());
    }

    /// <summary>
    /// Get note
    /// </summary>
    [HttpGet]
    [Route("one")]
    public async Task<ActionResult<FullNoteDTO>> GetNote([FromQuery] Guid noteId)
    {

        return Ok(await _noteService.GetNote(noteId));
    }
}