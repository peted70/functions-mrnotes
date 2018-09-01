using Microsoft.Azure.WebJobs;
using MRNotes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mrnotes.DataSource
{
    public class CosmosDataSource : IDataSource
    {
        private IAsyncCollector<MRNote> _collector;

        public CosmosDataSource(IAsyncCollector<MRNote> collector)
        {
            _collector = collector;
        }
        public async Task AddNoteAsync(MRNote note)
        {
            await _collector.AddAsync(note);
        }

        public Task<MRNote> DeleteNoteAsync(string id)
        {
            return Task.FromResult<MRNote>(null);
        }

        public Task<IEnumerable<MRNote>> GetNotesAsync()
        {
            return Task.FromResult<IEnumerable<MRNote>>(null);
        }
    }
}
