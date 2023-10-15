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
            [JsonProperty("serviceCapability")]
            public string ServiceCapability { get; set; }
            [JsonProperty("serviceActivity")]
            public string ServiceActivity { get; set; }
        }

    }
}
