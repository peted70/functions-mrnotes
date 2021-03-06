﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MRNotes
{
    public class MRNote
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
