using System;
using System.Collections.Generic;
using System.Text;

namespace Yell.Models
{
    public static class Acoustics
    {
        /// <summary>
        /// Converts intesity from W/m² to dB
        /// </summary>
        /// <param name="intensity"></param>
        /// <returns></returns>
        public static double ToDb(this double intensity) =>
            10 * Math.Log10(intensity / Math.Pow(10, -12));
    }
}
