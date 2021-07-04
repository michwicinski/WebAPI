using NotesOrganizer.Core.Domain;
using NotesOrganizer.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesOrganizer.Infrastructure.Services
{
    public interface INoteService
    {
        NoteDto Get(Guid Id);
        IEnumerable<NoteDto> GetAll();
        NoteDto Create(Guid Id, string title, string content);
        NoteDto Update(Guid Id, string title, string content);
        void Delete(Guid Id);
    }
}
