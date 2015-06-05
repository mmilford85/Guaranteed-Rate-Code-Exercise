namespace GRCE.Console
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Console = System.Console;

    using GRCE.Domain.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Invalid number of files specified");

                return;
            }

            var pipeRecords = ReadRecordsFromFile(args[0], " | ");
            var commaRecords = ReadRecordsFromFile(args[1], ", ");
            var spaceRecord = ReadRecordsFromFile(args[2], " ");

            var allRecords = new List<Record>(pipeRecords);
            allRecords.AddRange(commaRecords);
            allRecords.AddRange(spaceRecord);

            OutputRecords(allRecords);

#if DEBUG
            Console.ReadLine();
#endif
        }

        private static IEnumerable<Record> ReadRecordsFromFile(string fileName, string delimter)
        {
            if (!File.Exists(fileName))
            {
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
