using NotesApp.Models;
using System.Linq.Expressions;

public interface INoteRepository
{
    Task<Note?> GetAsync(int id);
    Task<List<Note>> ListAsync(Expression<Func<Note, bool>>? filter = null);
    Task AddAsync(Note note);
    Task UpdateAsync(Note note);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
