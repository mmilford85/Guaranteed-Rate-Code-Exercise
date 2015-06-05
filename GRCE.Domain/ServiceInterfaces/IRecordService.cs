namespace GRCE.Domain.ServiceInterfaces
{
    using GRCE.Domain.Models;

    public interface IRecordService
    {
        ParseRecordResult ParseString(string recordString, string[] delimiters);
    }
}
