namespace GRCE.Domain.Models
{
    public class ParseRecordResult
    {
        public ParseRecordResult(bool isValid, string errorMessage, Record record)
        {
            this.IsValid = isValid;

            this.ErrorMessage = errorMessage;

            this.Record = record;
        }

        public bool IsValid { get; private set; }

        public string ErrorMessage { get; private set; }

        public Record Record { get; private set; }
    }
}