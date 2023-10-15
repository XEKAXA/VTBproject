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
                  string suoAvailability, string hasRamp, double latitude, double longitude, string metroStation,
                  int distance, string kep, bool myBranch)
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
            if (metroStation != null) MetroStation = metroStation;
            else MetroStation = string.Empty;
            Distance = distance;
            if (kep == null) Kep = false;
            else Kep = Convert.ToBoolean(kep);
            MyBranch = myBranch;
        }
        [JsonProperty("salePointName")]
        public string SalePointName { get; private set; }
        [JsonProperty("address")]
        public string Address { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("openHours")]
        public List<OpenHours> ListOpenHours { get; private set; }
        [JsonProperty("rko")]
        public string Rko { get; private set; }
        [JsonProperty("openHoursIndividual")]
        public List<OpenHours> OpenHoursIndividual { get; private set; }
        [JsonProperty("officeType")]
        public string OfficeType { get; private set; }
        [JsonProperty("salePointFormat")]
        public string SalePointFormat { get; private set; }
        [JsonProperty("suoAvailability")]
        public string SuoAvailability { get; private set; }
        [JsonProperty("hasRamp")]
        public string HasRamp { get; private set; }
        [JsonProperty("latitude")]
        public double Latitude { get; private set; }
        [JsonProperty("longitude")]
        public double Longitude { get; private set; }
        [JsonProperty("metroStation")]
        public object MetroStation { get; private set; }
        [JsonProperty("distance")]
        public int Distance { get; private set; }
        [JsonProperty("kep")]
        public bool Kep { get; private set; }
        [JsonProperty("myBranch")]
        public bool MyBranch { get; private set; }

        public class OpenHours
        {
            public OpenHours(string day, string hour)
            {
                Days = day;
                Hours = hour;
            }
            [JsonProperty("days")]
            public string Days { get; set; }
            [JsonProperty("hours")]
            public string Hours { get; set; }
        }
    }
}
    