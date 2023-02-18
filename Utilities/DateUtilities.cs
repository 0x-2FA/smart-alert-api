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

        public string GetDateOnlyString(string timestamp)
        {
            DateTime timestampDateTime = DateTime.Parse(timestamp);

            DateOnly dateOnly = DateOnly.FromDateTime(timestampDateTime);

            return dateOnly.ToString();
        }

        public string DatePreviousDayString(string date)
        {
            DateTime dateTime = DateTime.Parse(date);

            DateTime previousDateTime = dateTime.AddDays(-1);

            return GetDateOnlyString(previousDateTime.ToString());
        }

        public string DatePreviousDayCustomString(string date, string format)
        {
            DateTime dateTime = DateTime.Parse(date);

            DateTime previousDateTime = dateTime.AddDays(-1);

            return previousDateTime.ToString(format);
        }

    }
}
