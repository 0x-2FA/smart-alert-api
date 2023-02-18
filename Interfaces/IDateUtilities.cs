namespace smart_alert_api.Interfaces
{
    public interface IDateUtilities
    {
        public string NowDefaultString();

        public string NowCustomString(string format);

        public string GetDateOnlyString(string timestamp);

        public string DatePreviousDayString(string date);

        public string DatePreviousDayCustomString(string date, string format);

    }
}
