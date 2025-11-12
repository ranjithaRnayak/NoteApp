using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

public class NotesAppContext : DbContext
    {
        public NotesAppContext(DbContextOptions<NotesAppContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for Notes entities here, 
        public DbSet<Note> Notes { get; set; } = null!;
    }