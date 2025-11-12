# NotesApp (ASP.NET Core MVC)

A minimal Notes app built with ASP.NET Core MVC + EF Core + Css (light).

## Features (Phase 1)
- Create / List / Edit / Delete notes
- Priority (Low/Medium/High)
- Server-side timestamps (CreatedAtUtc, UpdatedAtUtc)
- Clean minimal UI (tiny custom CSS)

> `CategoryId` and `IsArchived` exist in the model for future phases but are hidden in the UI for now.

## Tech
- ASP.NET Core MVC (.NET 8)
- EF Core (SQL Server / LocalDB)
- css, bootstrap (minimal)

## Getting Started

### 1) Config
Check `appsettings.json`:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\SQLEXPRESS;Database=NotesApp;Trusted_Connection=True;MultipleActiveResultSets=true"
}
2) Register Service in Program.cs (DbContext)
builder.Services.AddDbContext<NotesAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<INoteRepository, EFNoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

3) Change default controller in Program.cs to Notes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notes}/{action=Index}/{id?}");


## Project Structure
 appsettings.Development.json
│   appsettings.json
│   NotesApp.csproj
│   NotesApp.sln
│   Program.cs
│   README.md
│
├───Controllers
│    
│       NotesController.cs
│
├───Data
│   │   NotesAppContext.cs
│   │   NotesAppContextFactory.cs
│   │
│   └───Repositories
│           EFNoteRepository.cs
│           INoteRespository.cs
│
├───Migrations
│       20251112182556_InitialCreate.cs
│       20251112182556_InitialCreate.Designer.cs
│       NotesAppContextModelSnapshot.cs
│
├───Models      
│       Note.cs
├───Services
│       INoteService.cs
│       NoteService.cs
│
├───Views
│   │
│   ├───Notes
│   │       Create.cshtml
│   │       Delete.cshtml
│   │       Edit.cshtml
│   │       Index.cshtml
│   │       _NoteCard.cshtml
│   │       _NoteForm.cshtml
│   │
│   └───Shared
│           _Layout.cshtml
│           
│
└───wwwroot
    │   
    ├───css
           notes.css
        
### create DB if not created
dotnet ef migrations add InitialCreate
dotnet ef database update