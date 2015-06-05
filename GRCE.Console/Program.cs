namespace GRCE.Console
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using GRCE.Domain;
    using GRCE.Domain.Extensions;
    using GRCE.Domain.Models;

    using Console = System.Console;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Invalid number of files specified");

                return;
            }

            var pipeRecords = ReadRecordsFromFile(args[0], Constants.RecordStringDelimeters.PipeDelimter);
            var commaRecords = ReadRecordsFromFile(args[1], Constants.RecordStringDelimeters.CommaDelimter);
            var spaceRecord = ReadRecordsFromFile(args[2], Constants.RecordStringDelimeters.SpaceDelimter);

            var allRecords = new List<Record>(pipeRecords);
            allRecords.AddRange(commaRecords);
            allRecords.AddRange(spaceRecord);

            Console.WriteLine("\nRecords sorted by gender\n");

            OutputRecords(allRecords.OrderByGender());

            Console.WriteLine("\nRecords sorted by birth date\n");

            OutputRecords(allRecords.OrderByDob());

            Console.WriteLine("\nRecords sorted by last name\n");

            OutputRecords(allRecords.OrderByLastName());

#if DEBUG
            Console.ReadLine();
#endif
        }

        private static IEnumerable<Record> ReadRecordsFromFile(string fileName, string delimter)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine(string.Format("File {0} does not exist", fileName));

                return Enumerable.Empty<Record>();
            }

            var delimiterArray = new string[] { delimter };
            
            var fileLines = File.ReadAllLines(fileName);
            var records = new List<Record>(fileLines.Length);

            foreach (var parseResult in fileLines.Select(line => Record.ParseRecordFromString(line, delimiterArray)))
            {
                if (parseResult.IsValid)
                {
                    records.Add(parseResult.Record);
                }
                else
                {
                    Console.WriteLine(parseResult.ErrorMessage);
                }
            }

            return records;
        }

        private static void OutputRecords(IEnumerable<Record> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine(
                    string.Format(
                        "\nRecord:\nFirst Name: {0}\nLast Name: {1}\nGender: {2}\nFavorite Color: {3}\nDate of Birth: {4}",
                        record.FirstName,
                        record.LastName,
                        record.GenderDisplayString,
                        record.FavoriteColor,
                        record.DobDisplayString));
            }
        }
    }
}
