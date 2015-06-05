namespace GRCE.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using GRCE.Domain.Models;

    public static class RecordExtensions
    {
        public static IEnumerable<Record> OrderByGender(this IEnumerable<Record> records)
        {
            return records.OrderBy(record => record.Gender).ThenBy(record => record.LastName);
        }

        public static IEnumerable<Record> OrderByDob(this IEnumerable<Record> records)
        {
            return records.OrderBy(record => record.DateOfBirth);
        }

        public static IEnumerable<Record> OrderByLastName(this IEnumerable<Record> records)
        {
            return records.OrderByDescending(record => record.LastName);
        }
    }
}
