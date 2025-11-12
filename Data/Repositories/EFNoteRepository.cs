using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

public class EFNoteRepository : INoteRepository 
{
    private readonly NotesAppContext _context;

    public EFNoteRepository(NotesAppContext context)
    {
        _context = context;
    }

    public async Task<Note?> GetAsync(int id)
    {
        return await _context.Notes.FindAsync(id);
    }

    public async Task<List<Note>> ListAsync(Expression<Func<Note, bool>>? filter = null)
    {
        if (filter != null)
        {
            return await _context.Notes.Where(filter).ToListAsync();
        }
        return await _context.Notes.OrderByDescending(n => n.CreatedAtUtc).ToListAsync();
    }

    public async Task AddAsync(Note note)
    {
        await _context.Notes.AddAsync(note);
    }

    public async Task UpdateAsync(Note note)
    {
        _context.Notes.Update(note);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var note = await GetAsync(id);
        if (note != null)
        {
            _context.Notes.Remove(note);
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}