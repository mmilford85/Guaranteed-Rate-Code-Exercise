namespace GRCE.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    using GRCE.Domain.Enums;
    using GRCE.Domain.Extensions;

    [DataContract]
    public class Record
    {
        public Record(string firstName, string lastName, Gender gender, string favoriteColor, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.FavoriteColor = favoriteColor;
            this.DateOfBirth = dateOfBirth;
        }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string LastName { get; private set; }

        public Gender Gender { get; private set; }

        [DataMember(Name = "Gender")]
        public string GenderDisplayString
        {
            get
            {
                return this.Gender.ToString();
            }
        }

        [DataMember]
        public string FavoriteColor { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        [DataMember(Name = "DateOfBirth")]
        public string DobDisplayString
        {
            get
            {
                return this.DateOfBirth.ToDobDisplayString();
            }
        }

        public static ParseRecordResult CreateRecordFromString(string recordString, string[] delimiters)
        {
            var recordVals = recordString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (recordVals.Length != 5)
            {
                return ParseErrorResult(
                    recordString,
                    delimiters,
                    string.Format("Record contains an invalid number ({0}) of fields", recordVals.Length));
            }

            var genderString = recordVals[2];
            var gender = ParseGender(genderString);

            if (gender == Enums.Gender.Unspecified)
            {
                return ParseErrorResult(
                    recordString,
                    delimiters,
                    string.Format("Cannot parse gender from {0}", genderString));
            }

            var dobString = recordVals[4];
            var dob = ParseDob(dobString);

            if (dob == default(DateTime))
            {
                return ParseErrorResult(
                    recordString,
                    delimiters,
                    string.Format("Cannot parse dob from {0}", dobString));
            }

            var firstName = recordVals[1];
            var lastName = recordVals[0];
            var favoriteColor = recordVals[3];

            return new ParseRecordResult(
                true,
                string.Empty,
                new Record(firstName, lastName, gender, favoriteColor, dob));
        }

        private static Gender ParseGender(string genderString)
        {
            var returnVal = Enums.Gender.Unspecified;

            if (Enums.Gender.TryParse(genderString, true, out returnVal))
            {
                return returnVal;
            }

            return Enums.Gender.Unspecified;
        }

        private static DateTime ParseDob(string dobString)
        {
            var returnVal = default(DateTime);

            if (DateTime.TryParse(dobString, out returnVal))
            {
                return returnVal;
            }

            return default(DateTime);
        }

        private static ParseRecordResult ParseErrorResult(string recordString, string[] delimterStrings, string errorMessage)
        {
            var fullErrorMessage = string.Format(
                "Could not parse {0} with delimters {1}, Error Message: {2}",
                recordString,
                string.Join(", ", delimterStrings),
                errorMessage);

            return new ParseRecordResult(false, fullErrorMessage, null);
        }
    }
}
