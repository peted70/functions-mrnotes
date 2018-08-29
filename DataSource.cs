using System;
using System.Collections.Generic;
using System.Text;

namespace MRNotes
{
    internal class DataSource
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
    }
}
