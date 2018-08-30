using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void AddNote(MRNote note)
        {
            Notes.Add(note);
        }

        public MRNote DeleteNote(string id)
        {
            var item = Notes.SingleOrDefault(n => n.Id == id);
            if (item != null)
                Notes.Remove(item);
            return item;
        }

        public IEnumerable<MRNote> GetNotes()
        {
            return Notes;
        }
    }
}
