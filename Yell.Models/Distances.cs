using System;

namespace Yell.Models
{
    public static class Distances
    {
        /// <summary>
        /// Calculates grand circle haversine distance
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <returns></returns>
        public static double CalculateHaversine(double lat1, double lon1, double lat2, double lon2)
        {
            const int r = 6372800; // In kilometers
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + 
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);

            return r * 2 * Math.Asin(Math.Sqrt(a));
        }

        /// <summary>
        /// Calculates grand circle haversine distance
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        public static double CalculateHaversine(Tuple<double, double> pos1, Tuple<double, double> pos2) =>
            CalculateHaversine(pos1.Item1, pos1.Item2, pos2.Item1, pos2.Item2);

        /// <summary>
        /// Converts decimal degrees to radian degrees
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static double ToRadians(double angle) =>
            Math.PI * angle / 180.0;
    }
}
