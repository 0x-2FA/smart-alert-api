namespace smart_alert_api.Interfaces
{
    public interface IDateUtilities
    {
        public string NowDefaultString();

        public string NowCustomString(string format);

    }
}
