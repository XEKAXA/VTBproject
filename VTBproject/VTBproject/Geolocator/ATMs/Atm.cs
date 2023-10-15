using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTBproject.Geolocator.ATMs
{
    public class ATM
    {
        public ATM(string address, double latitude, double logitude, bool allDay, Services services) 
        { 
            this.Address = address;
            this.Latitude = latitude;
            this.Longitude = logitude;
            this.AllDay = allDay;
            this.AvailableServices = services;
        }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool AllDay { get; set; }
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
            public Service Wheelchair { get; set; }
            public Service Blind { get; set; }
            public Service NfcForBankCards { get; set; }
            public Service QrRead { get; set; }
            public Service SupportsUsd { get; set; }
            public Service SupportsChargeRub { get; set; }
            public Service SupportsEur { get; set; }
            public Service SupportsRub { get; set; }
        }
        public class Service
        {
            public Service(string serviceCapability, string serviceActivity)
            {
                this.ServiceCapability = serviceCapability;
                this.ServiceActivity = serviceActivity;
            }
            public string ServiceCapability { get; set; }
            public string ServiceActivity { get; set; }
        }

    }
}
