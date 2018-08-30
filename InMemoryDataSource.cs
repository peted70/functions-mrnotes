using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNotes
{
    internal class InMemoryDataSource : IDataSource
    {
        public static List<MRNote> Notes { get; set; } = new List<MRNote>()
        {
            new MRNote
            {
                Author = "Pete D",
                Created = DateTime.UtcNow,
                Title = "Note 1",
                Description = "First note by Pete D"
            }
        };

         public Task<MRNote> DeleteNoteAsync(string id)
        {
            var item = Notes.SingleOrDefault(n => n.Id == id);
            if (item != null)
                Notes.Remove(item);
            return Task.FromResult(item);
        }

         public Task<IEnumerable<MRNote>> GetNotesAsync()
        {
            return Task.FromResult(Notes.AsEnumerable());
        }

        Task IDataSource.AddNoteAsync(MRNote note)
        {
            Notes.Add(note);
            return Task.FromResult(0);
        }
    }
}
