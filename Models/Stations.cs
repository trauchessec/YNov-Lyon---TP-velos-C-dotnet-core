using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Tools;
using System.Globalization;
using BikeWatcher.Models;

namespace BikeWatcher.Models
{
    public class Stations
    {
        public Stations()
        {

        }

        public Stations(StationBordeaux bordeaux)
        {
            available_bikes = bordeaux.bike_count_total.ToString();
            lng = bordeaux.longitude;
            lat = bordeaux.latitude;
            bike_stands = bordeaux.slot_count.ToString();
            name = bordeaux.name;
            available_bike_stands = bordeaux.slot_count.ToString();
        }

        public string number { get; set; }
        public string pole { get; set; }
        public string available_bikes { get; set; }
        public string code_insee { get; set; }
        public string lng { get; set; }
        public string availability { get; set; }
        public string availabilitycode { get; set; }
        public string etat { get; set; }
        public string startdate { get; set; }
        public string langue { get; set; }
        public string bike_stands { get; set; }
        public string last_update { get; set; }
        public string available_bike_stands { get; set; }
        public string gid { get; set; }
        public string titre { get; set; }
        public string status { get; set; }
        public string commune { get; set; }
        public string description { get; set; }
        public string nature { get; set; }
        public string bonus { get; set; }
        public string address2 { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string last_update_fme { get; set; }
        public string enddate { get; set; }
        public string name { get; set; }
        public string banking { get; set; }
        public string nmarrond { get; set; }

        public double CompareDistance(double latitudeUser, double longitudeUser)
        {
            return DistanceGeo.GetDistanceBetweenPoints(double.Parse(lat, CultureInfo.InvariantCulture), double.Parse(lng, CultureInfo.InvariantCulture), latitudeUser, longitudeUser);
        }
    }
}
