using System.Collections.Generic;

namespace MRNotes
{
    interface IDataSource
    {
        IEnumerable<MRNote> GetNotes();
        void AddNote(MRNote note);
        MRNote DeleteNote(string id);
    }

    class DataSource
    {
        private static IDataSource _instance;

        public static IDataSource Instance()
        {
            if (_instance == null)
                _instance = new InMemoryDataSource();
            return _instance;
        }
    }
}
