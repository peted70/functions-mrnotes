using System;
using System.Collections.Generic;
using System.Text;

namespace MRNotes
{
    internal class MRNote
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
