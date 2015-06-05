namespace GRCE.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using GRCE.Domain.Models;

    public class RecordsController : ApiController
    {
        // POST: /records
        [HttpPost]
        public ParseRecordResult Post(string record)
        {
            return new ParseRecordResult(false, "Method Not Implemented yet", null);
        }

        // GET: /records/gender
        [HttpGet]
        public IEnumerable<Record> Gender()
        {
            return new List<Record>
                       {
                           new Record(
                                   "Gender",
                                   "Gender",
                                   Domain.Enums.Gender.Female,
                                   "Gender",
                                   DateTime.Now)
                       };
        }

        // GET: /records/birthdate
        [HttpGet]
        public IEnumerable<Record> Birthdate()
        {
            return new List<Record>
                       {
                           new Record(
                                   "Birthdate",
                                   "Birthdate",
                                   Domain.Enums.Gender.Female,
                                   "Birthdate",
                                   DateTime.Now)
                       };
        }

        // GET: /records/name
        [HttpGet]
        public IEnumerable<Record> Name()
        {
            return new List<Record>
                       {
                           new Record(
                                   "Birthdate",
                                   "Birthdate",
                                   Domain.Enums.Gender.Female,
                                   "Birthdate",
                                   DateTime.Now)
                       };
        }
    }
}
