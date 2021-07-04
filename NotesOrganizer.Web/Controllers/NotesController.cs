using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesOrganizer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotesOrganizer.Web.Controllers
{
    public class NotesController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        

        public async Task<IActionResult> Index()
        {
            List<Note> notes = await GetAllNotes();

            return View(notes);
        }

        public NotesController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
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
    }
}
