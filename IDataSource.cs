using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRNotes
{
    interface IDataSource
    {
        Task<IEnumerable<MRNote>> GetNotesAsync();
        Task AddNoteAsync(MRNote note);
        Task<MRNote> DeleteNoteAsync(string id);
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
