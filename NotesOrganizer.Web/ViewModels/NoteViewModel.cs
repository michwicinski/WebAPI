using NotesOrganizer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesOrganizer.Web.ViewModels
{
    public class NoteViewModel
    {
        public IEnumerable<Note> AllNotes { get; set; }
        public Note Note { get; set; }
    }
}
