using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWatcher.Tools
{
    public class DistanceGeo
    {
        public static double GetDistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = long1 - long2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

           return dist * 1.609344;
        }
    }
}
