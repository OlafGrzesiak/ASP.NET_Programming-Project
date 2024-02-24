namespace Labolatorium_3_App.Models
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }

    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
