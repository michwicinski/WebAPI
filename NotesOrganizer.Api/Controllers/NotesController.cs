using Microsoft.AspNetCore.Mvc;
using NotesOrganizer.Core.Domain;
using NotesOrganizer.Infrastructure.DTO;
using NotesOrganizer.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesOrganizer.Api.Controllers
{
    [Route("api/Notes")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var notes = _noteService.GetAll();

            return Ok(notes);
        }

        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var note = _noteService.Get(id);
            if(note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        public IActionResult Create(NoteDto note)
        {
            var newId = Guid.NewGuid();
            var createdNote = _noteService.Create(newId, note.Title, note.Content);

            return CreatedAtAction(nameof(Get), new { newId }, createdNote);
        }

        [HttpPut("id")]
        public IActionResult Update(Guid Id, Note note)
        {
            _noteService.Update(Id, note.Title, note.Content);

            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(Guid Id)
        {
            _noteService.Delete(Id);

            return NoContent();
        }
    }
}
