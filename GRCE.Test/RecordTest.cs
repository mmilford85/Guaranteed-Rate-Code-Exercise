namespace GRCE.Test
{
    using System;
    using System.Collections.Generic;

    using GRCE.Domain;
    using GRCE.Domain.Enums;
    using GRCE.Domain.Models;

    using NUnit.Framework;

    [TestFixture]
    public class RecordTest
    {
        private static IEqualityComparer<Record> _recordEqualityComparer = new RecordEqualityComparer();

        [Test]
        public void ValidRecordParse()
        {
            var recordString = "Priest, Holly, Female, Blue, 6/12/1985";

            var recordParseResult = Record.ParseRecordFromString(
                recordString,
                new string[] { Constants.RecordStringDelimeters.CommaDelimter });

            ValidateParseRecordResult(
                recordParseResult,
                true,
                string.Empty,
                new Record("Holly", "Priest", Gender.Female, "Blue", new DateTime(1985, 6, 12)));
        }

        [Test]
        public void InvalidRecordParseDelimiter()
        {
            var recordString = "Priest, Holly, Female, Blue, 6/12/1985";

            var recordParseResult = Record.ParseRecordFromString(
                recordString,
                new string[] { Constants.RecordStringDelimeters.PipeDelimter });

            ValidateParseRecordResult(
                recordParseResult,
                false,
                FormatErrorString(
                    recordString,
                    Constants.RecordStringDelimeters.PipeDelimter,
                    "Record contains an invalid number (1) of fields"),
                null);
        }

        [Test]
        public void InvalidRecordParseGender()
        {
            var recordString = "Priest, Holly, Fele, Blue, 6/12/1985";

            var recordParseResult = Record.ParseRecordFromString(
                recordString,
                new string[] { Constants.RecordStringDelimeters.CommaDelimter });

            ValidateParseRecordResult(
                recordParseResult,
                false,
                FormatErrorString(
                    recordString,
                    Constants.RecordStringDelimeters.CommaDelimter,
                    "Cannot parse gender from Fele"),
                null);
        }

        [Test]
        public void InvalidRecordParseDob()
        {
            var recordString = "Priest, Holly, Female, Blue, 76/12/17985";

            var recordParseResult = Record.ParseRecordFromString(
                recordString,
                new string[] { Constants.RecordStringDelimeters.CommaDelimter });

            ValidateParseRecordResult(
                recordParseResult,
                false,
                FormatErrorString(
                    recordString,
                    Constants.RecordStringDelimeters.CommaDelimter,
                    "Cannot parse dob from 76/12/17985"),
                null);
        }

        private static string FormatErrorString(string recordString, string delimiter, string errorMessage)
        {
            return string.Format(
                "Could not parse {0} with delimters {1}, Error Message: {2}",
                recordString,
                delimiter,
                errorMessage);
        }

        private static void ValidateParseRecordResult(ParseRecordResult recordResult, bool valid, string errorMessage, Record record)
        {
            Assert.AreEqual(recordResult.IsValid, valid);
            Assert.AreEqual(recordResult.ErrorMessage, errorMessage);

            if (record == null)
            {
                Assert.AreEqual(recordResult.Record, record);
            }
            else
            {
                Assert.AreEqual(recordResult.Record.FirstName, record.FirstName);
                Assert.AreEqual(recordResult.Record.LastName, record.LastName);
                Assert.AreEqual(recordResult.Record.Gender, record.Gender);
                Assert.AreEqual(recordResult.Record.FavoriteColor, record.FavoriteColor);
                Assert.AreEqual(recordResult.Record.DateOfBirth, record.DateOfBirth);
            }
        }
    }
}
