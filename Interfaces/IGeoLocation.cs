using Geolocation;

namespace smart_alert_api.Interfaces
{
    public interface IGeoLocation
    {
        public double GetDistanceInKm(double latitude, double longitude, double otherLatitude, double otherLongitude);
        public CoordinateBoundaries SetRadiusBoundaries(double latitude, double longitude, int radius);
    }
}
