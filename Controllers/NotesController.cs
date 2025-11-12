using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;

public class NotesController : Controller
{
    
    private readonly INoteService _noteService;

    public NotesController( INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<IActionResult> Index()
    {
        var notes = await _noteService.GetAllNotesAsync();
        return View(notes);
    }
    [HttpGet]
    public IActionResult Create() => View(new Note());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Content,Priority,CategoryId")] Note note)
    {
        if (ModelState.IsValid)
        {
            await _noteService.CreateNoteAsync(note);
            return RedirectToAction(nameof(Index));
        }
        return View(note);
    }
   
   [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var note = await _noteService.GetNoteAsync(id);
        if (note is null) return NotFound();
        return View(note);
    }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([Bind("Id,Title,Content,Priority,CategoryId,IsArchived")] Note note)
    {
        if (ModelState.IsValid)
        {
            await _noteService.UpdateNoteAsync(note);
            return RedirectToAction(nameof(Index));
        }
        return View(note);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var note = await _noteService.GetNoteAsync(id);
        if (note is null) return NotFound();
        return View(note);
    }


    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteNote([FromRoute] int id)
    {
        await _noteService.DeleteNoteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
public async Task<IActionResult> QuickEdit(int id)
{
    var note = await _noteService.GetNoteAsync(id);
    if (note is null) return NotFound();
    return PartialView("_QuickEditForm", note);
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> QuickEdit(Note note)
    {
        if (!ModelState.IsValid) return PartialView("_QuickEditForm", note);
        await _noteService.UpdateNoteAsync(note);
        return PartialView("_NoteCard", note); 
    }
}