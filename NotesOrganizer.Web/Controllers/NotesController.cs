using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesOrganizer.Web.Models;
using NotesOrganizer.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotesOrganizer.Web.Controllers
{
    public class NotesController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        
        public async Task<IActionResult> Index()
        {
            List<Note> notes = await GetAllNotes();

            NoteViewModel allNotes = new NoteViewModel();
            allNotes.AllNotes = notes;

            return View(allNotes);
        }

        public async Task<IActionResult> NoteForm(string id)
        {
            Note note = await GetNote(id);

            return View(note);
        }

        public NotesController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<Note> GetNote(string id)
        {
            Note note = new Note();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44392/api/Notes/id?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    note = JsonConvert.DeserializeObject<Note>(apiResponse);
                }
            }

            return note;
        }

        [HttpGet]
        public async Task<List<Note>> GetAllNotes()
        {
            List<Note> notes = new List<Note>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44392/api/Notes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    notes = JsonConvert.DeserializeObject<List<Note>>(apiResponse);
                }
            }

            return notes;
        }

        [HttpPost]
        public async Task<ActionResult> AddNote(Note note)
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
                await httpClient.PostAsync("https://localhost:44392/api/Notes", content);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditNote(Note note)
        {
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
                await httpClient.PutAsync("https://localhost:44392/api/Notes/id?id=" + note.Id, content);
            }

            return RedirectToAction("Index");
        }
    }
}
