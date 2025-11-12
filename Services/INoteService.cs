using NotesApp.Models;

public interface INoteService
{
    Task<Note?> GetNoteAsync(int id);
    Task<List<Note>> GetAllNotesAsync();
    Task CreateNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
}