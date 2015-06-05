namespace GRCE.Domain.ServiceInterfaces
{
    using System.Collections.Generic;

    using GRCE.Domain.Models;

    public interface IWebApiRecordService : IRecordService
    {
        IEnumerable<Record> GetStoredRecords();

        void AddRecord(Record record);
    }
}