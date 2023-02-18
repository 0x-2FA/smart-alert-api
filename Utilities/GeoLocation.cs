using Geolocation;
using smart_alert_api.Interfaces;

namespace smart_alert_api.Utilities
{
    public class GeoLocation : IGeoLocation
    {
        public double GetDistanceInKm(double latitude, double longitude, double otherLatitude, double otherLongitude)
        {
            var mileToKm = 1.609344;
            return GeoCalculator.GetDistance(latitude, longitude, otherLatitude, otherLongitude) * mileToKm;
        }
    }
}
