namespace GRCE.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using GRCE.Domain;
    using GRCE.Domain.Extensions;
    using GRCE.Domain.Models;
    using GRCE.Domain.ServiceInterfaces;

    public class RecordsController : ApiController
    {
        private readonly IWebApiRecordService _recordService;
        
        public RecordsController(IWebApiRecordService recordService)
        {
            if (recordService == null) throw new ArgumentNullException("recordService");

            this._recordService = recordService;
        }

        // POST: /records
        [HttpPost]
        public ParseRecordResult Index(string lastName, string firstName, string gender, string favoriteColor, string dob)
        {
            var record = string.Join(
                Constants.RecordStringDelimeters.PipeDelimter,
                new string[] { lastName, firstName, gender, favoriteColor, dob });

            var parseRecordResult = this._recordService.ParseString(record, new string[] { Constants.RecordStringDelimeters.PipeDelimter });

            if (!parseRecordResult.IsValid)
            {
                return parseRecordResult;
            }

            this._recordService.AddRecord(parseRecordResult.Record);

            return parseRecordResult;
        }

        // GET: /records/gender
        [HttpGet]
        public IEnumerable<Record> Gender()
        {
            return this._recordService.GetRecords().OrderByGender();
        }

        // GET: /records/birthdate
        [HttpGet]
        public IEnumerable<Record> Birthdate()
        {
            return this._recordService.GetRecords().OrderByDob();
        }

        // GET: /records/name
        [HttpGet]
        public IEnumerable<Record> Name()
        {
            return this._recordService.GetRecords().OrderByLastName();
        }
    }
}
