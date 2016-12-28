using System;
using System.Collections.Generic;
using System.Text;

namespace Yell.Models
{
    public static class Acoustics
    {
        public static double ToDb(this double intensity) =>
            10 * Math.Log10(intensity / Math.Pow(10, -12));
    }

    public static class Haversine
    {
        public static double Calculate(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6372800; // In kilometers
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }

        public static double Calculate(Tuple<double, double> pos1, Tuple<double, double> pos2) =>
            Calculate(pos1.Item1, pos1.Item2, pos2.Item1, pos2.Item2);

        public static double ToRadians(double angle) =>
            Math.PI * angle / 180.0;
    }
}
