namespace GRCE.Domain.Models
{
    using System;
    using System.Runtime.Serialization;

    using GRCE.Domain.Enums;
    using GRCE.Domain.Extensions;

    [DataContract]
    public class Record
    {
        public static ParseRecordResult CreateRecordFromString(string recordString, string[] delimiters)
        {
            return new ParseRecordResult(false, "Method Not Implemented", null);
        }
        
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
    }
}
