using ExtensibilityMVC.Models;

namespace ExtensibilityMVC.LoggerInfo
{
    /// <summary>
    /// Interface for the Logging
    /// </summary>
    public interface IRequestLogger
    {
        void RecordLog(LoggerInformation logInfo);
    }
    /// <summary>
    /// The class for Loggin the Request Information into the database usign ADO.NET EF
    /// </summary>
    public class RequestLogger : IRequestLogger
    {
        Database1Entities1 objContext;
        public RequestLogger()
        {
            objContext = new Database1Entities1();
        }

        public void RecordLog(LoggerInformation logInfo)
        {
            objContext.LoggerInformations.Add(logInfo);
            objContext.SaveChanges();
        }
    }
}