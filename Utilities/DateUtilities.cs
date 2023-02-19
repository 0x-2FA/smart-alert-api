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

        public TimeOnly TimeNowDefault()
        {
            TimeOnly timeOnlyNow = TimeOnly.FromDateTime(DateTime.Now);

            return timeOnlyNow;
        }

        public TimeOnly TimeBeforeDefault(int hoursToSubtract)
        {
            TimeOnly timeOnlyNow = TimeOnly.FromDateTime(DateTime.Now);

            TimeOnly timeOnlyBefore = timeOnlyNow.AddHours(-hoursToSubtract);

            return timeOnlyBefore;
        }

        public string TimeNowDefaultString()
        {
            TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);

            String now = timeOnly.ToString("HH:mm");

            return now;
        }

        public string TimeBeforeDefaultString(int hoursToSubtract)
        {
            TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);

            timeOnly.AddHours(-hoursToSubtract);

            String now = timeOnly.ToString("HH:mm");

            return now;
        }

        public string TimeOnlyString(string timestamp)
        {
            DateTime timestampDateTime = DateTime.Parse(timestamp);

            TimeOnly timeOnly = TimeOnly.FromDateTime(timestampDateTime);

            return timeOnly.ToString("HH:mm");
        }

        public bool BetweenHoursFromNow(string timestamp)
        {
            DateTime timestampDateTime = DateTime.Parse(timestamp);

            TimeOnly timeOnly = TimeOnly.FromDateTime(timestampDateTime);

            if(timeOnly.IsBetween(TimeBeforeDefault(2), TimeNowDefault()))
            {
                return true;
            }
            
            return false;
        }

    }
}
