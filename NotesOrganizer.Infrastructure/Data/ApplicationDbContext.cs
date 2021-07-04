using Microsoft.EntityFrameworkCore;
using NotesOrganizer.Core.Domain;

namespace NotesOrganizer.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
