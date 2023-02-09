using smart_alert_api.Interfaces;

namespace smart_alert_api.Utilities
{
    public class DateUtilities : IDateUtilities
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public string NowDefaultString()
        {
            string format = "dd/MM/yyyy HH:mm";
            return DateTime.Now.ToString(format);
        }

        public string NowCustomString(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
