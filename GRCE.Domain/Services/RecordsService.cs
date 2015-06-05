namespace GRCE.Domain.Services
{
    using System.Collections.Generic;

    using GRCE.Domain.Models;
    using GRCE.Domain.ServiceInterfaces;

    public class RecordsService : IRecordService, IWebApiRecordService
    {
        private readonly List<Record> _recordsList = new List<Record>(); 

        public ParseRecordResult ParseString(string recordString, string[] delimiters)
        {
            return Record.ParseRecordFromString(recordString, delimiters);
        }

        public IEnumerable<Record> GetRecords()
        {
            return this._recordsList;
        }

        public void AddRecord(Record record)
        {
            this._recordsList.Add(record);
        }
    }
}
