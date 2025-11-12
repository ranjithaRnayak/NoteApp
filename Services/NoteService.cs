using NotesApp.Models;

public class NoteService : INoteService 
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Note?> GetNoteAsync(int id)
    {
        return await _noteRepository.GetAsync(id);
    }

    public async Task<List<Note>> GetAllNotesAsync()
    {
        return await _noteRepository.ListAsync();
    }

    public async Task CreateNoteAsync(Note note)
    {
        await _noteRepository.AddAsync(note);
        await _noteRepository.SaveChangesAsync();
    }

    public async Task UpdateNoteAsync(Note note)
    {
         note.UpdatedAtUtc = DateTime.UtcNow;
        await _noteRepository.UpdateAsync(note);
        await _noteRepository.SaveChangesAsync();
    }

    public async Task DeleteNoteAsync(int id)
    {
        await _noteRepository.DeleteAsync(id);
        await _noteRepository.SaveChangesAsync();
    }
}