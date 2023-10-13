using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VTBproject
{
    internal class Office
    {
        public Office(string salePointName, string address, string status, List<OpenHours> listOpenHours,
                  string rko, List<OpenHours> openHoursIndividual, string officeType, string salePointFormat,
                  string suoAvailability, string hasRamp, double latitude, double longitude, object metroStation,
                  int distance, bool kep, bool myBranch)
        {
            SalePointName = salePointName;
            Address = address;
            Status = status;
            ListOpenHours = listOpenHours;
            Rko = rko;
            OpenHoursIndividual = openHoursIndividual;
            OfficeType = officeType;
            SalePointFormat = salePointFormat;
            SuoAvailability = suoAvailability;
            HasRamp = hasRamp;
            Latitude = latitude;
            Longitude = longitude;
            MetroStation = metroStation;
            Distance = distance;
            Kep = kep;
            MyBranch = myBranch;
        }
        
        public string SalePointName { get; private set; }
        public string Address { get; private set; }
        public string Status { get; private set; }
        public List<OpenHours> ListOpenHours { get; private set; }
        public string Rko { get; private set; }
        public List<OpenHours> OpenHoursIndividual { get; private set; }
        public string OfficeType { get; private set; }
        public string SalePointFormat { get; private set; }
        public string SuoAvailability { get; private set; }
        public string HasRamp { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public object MetroStation { get; private set; }
        public int Distance { get; private set; }
        public bool Kep { get; private set; }
        public bool MyBranch { get; private set; }

        public class OpenHours
        {
            public OpenHours(string day, string hour)
            {
                Days = day;
                Hours = hour;
            }
            public string Days { get; set; }
            public string Hours { get; set; }
        }
    }
}
    