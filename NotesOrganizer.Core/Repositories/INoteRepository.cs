using Microsoft.AspNetCore.Mvc;
using NotesOrganizer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotesOrganizer.Core.Repositories
{
    public interface INoteRepository
    {
        Note Get(Guid Id);
        IEnumerable<Note> GetAll();
        Task Add(Note note);
        Task Update(Note note);
        Task Delete(Guid id);
    }
}
