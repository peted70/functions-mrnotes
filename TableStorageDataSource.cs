using System;
using System.Collections.Generic;
using System.Text;

namespace MRNotes
{
    class TableStorageDataSource : IDataSource
    {
        public void AddNote(MRNote note)
        {
            throw new NotImplementedException();
        }

        public MRNote DeleteNote(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MRNote> GetNotes()
        {
            throw new NotImplementedException();
        }
    }
}
