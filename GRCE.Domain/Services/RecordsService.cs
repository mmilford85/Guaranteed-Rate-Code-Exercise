namespace GRCE.Domain.Services
{
    using System.Collections.Generic;

    using GRCE.Domain.Models;
    using GRCE.Domain.ServiceInterfaces;

    public class RecordsService : IRecordService, IWebApiRecordService
    {
        public ParseRecordResult ParseString(string recordString, string[] delimiters)
        {
            return Record.ParseRecordFromString(recordString, delimiters);
        }

        public IEnumerable<Record> GetStoredRecords()
        {
            throw new System.NotImplementedException();
        }

        public void AddRecord(Record record)
        {
            throw new System.NotImplementedException();
        }
    }
}
