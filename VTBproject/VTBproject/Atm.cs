using Microsoft.Maui.Controls.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VTBproject.ATM;

namespace VTBproject
{
    internal class ATM
    {
        public ATM(string address, double latitude, double logitude, bool allDay) 
        { 
            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = logitude;
            this.AllDay = allDay;
            AvailableServices = new Services();
        }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("allDay")]
        public bool AllDay { get; set; }
        [JsonProperty("services")]
        public Services AvailableServices { get; set; }

        public class Services
        {
            public Services(Service wheelchair, Service blind, Service nfcForBankCards, Service qrRead,
                 Service supportsUsd, Service supportsChargeRub, Service supportsEur, Service supportsRub)
            {
                Wheelchair = wheelchair;
                Blind = blind;
                NfcForBankCards = nfcForBankCards;
                QrRead = qrRead;
                SupportsUsd = supportsUsd;
                SupportsChargeRub = supportsChargeRub;
                SupportsEur = supportsEur;
                SupportsRub = supportsRub;
            }
            public Services()
            {
                Wheelchair = new Service();
                Blind = new Service();
                NfcForBankCards = new Service();
                QrRead = new Service();
                SupportsUsd = new Service();
                SupportsChargeRub = new Service();
                SupportsEur = new Service();
                SupportsRub = new Service();
            }
            [JsonProperty("wheelchair")]
            public Service Wheelchair { get; set; }
            [JsonProperty("blind")]
            public Service Blind { get; set; }
            [JsonProperty("nfcForBankCards")]
            public Service NfcForBankCards { get; set; }
            [JsonProperty("qrRead")]
            public Service QrRead { get; set; }
            [JsonProperty("supportsUsd")]
            public Service SupportsUsd { get; set; }
            [JsonProperty("supportsChargeRub")]
            public Service SupportsChargeRub { get; set; }
            [JsonProperty("supportsEur")]
            public Service SupportsEur { get; set; }
            [JsonProperty("supportsRub")]
            public Service SupportsRub { get; set; }
        }
        public class Service
        {
            public Service()
            {
                this.ServiceCapability = "UNKOWN";
                this.ServiceActivity = "UNKOWN";
            }
            [JsonProperty("serviceCapability")]
            public string ServiceCapability { get; set; }
            [JsonProperty("serviceActivity")]
            public string ServiceActivity { get; set; }
        }

    }
}
