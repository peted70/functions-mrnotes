using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNotes
{
    internal static class Extensions
    {
        internal static MRNotesTableEntity ToTableEntity(this MRNote note)
        {
            return new MRNotesTableEntity
            {
                Created = note.Created,
                Author = note.Author,
                Description = note.Description,
                Title = note.Title,
                PartitionKey = "MRNotes",
                RowKey = note.Id
            };
        }
        internal static MRNote ToMRNote(this MRNotesTableEntity entity)
        {
            return new MRNote
            {
                Created = entity.Created,
                Author = entity.Author,
                Description = entity.Description,
                Title = entity.Title,
                Id = entity.RowKey
            };
        }
    }

    class MRNotesTableEntity : TableEntity
    {
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }

    class TableStorageDataSource : IDataSource
    {
        private CloudTable _table;

        public TableStorageDataSource(CloudTable table)
        {
            _table = table;
        }

        public async Task AddNoteAsync(MRNote note)
        {
            var entity = note.ToTableEntity();
            await _table.ExecuteAsync(TableOperation.Insert(entity));
        }

        public async Task<MRNote> DeleteNoteAsync(string id)
        {
            var res = await _table.ExecuteAsync(TableOperation.Delete(new MRNotesTableEntity { PartitionKey = "MRNotes", RowKey = id }));
            return res.Result as MRNote;
        }

        public async Task<IEnumerable<MRNote>> GetNotesAsync()
        {
            var query = new TableQuery<MRNotesTableEntity>();
            var segment = await _table.ExecuteQuerySegmentedAsync(query, null);
            return segment.Select(Extensions.ToMRNote);
        }
    }
}
