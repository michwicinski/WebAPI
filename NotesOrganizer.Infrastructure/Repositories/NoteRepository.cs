using NotesOrganizer.Core.Domain;
using NotesOrganizer.Core.Repositories;
using NotesOrganizer.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace NotesOrganizer.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Note Get(Guid Id)
        {
            return _dbContext.Notes.SingleOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _dbContext.Notes;
        }

        public async Task Add(Note note)
        {
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Note note)
        {
            var result = _dbContext.Notes.SingleOrDefault(x => x.Id == note.Id);

            if(result != null)
            {
                result.SetTitle(note.Title);
                result.SetContent(note.Content);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var note = await _dbContext.Notes.FindAsync(id);

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
        }
    }
}
