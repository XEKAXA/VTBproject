using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VTBproject.Geolocator.ATMs;
using VTBproject.Geolocator.Offices;

namespace VTBproject.Geolocator
{
    internal class Locator
    {
        public string GeolocatorApiKey { private get; set; } = "d46a2c82-1946-465d-a02c-b84e80ca528e";
        internal string GetLocation()
        {
            Office[] offices = GetOffices();
            ATM[] aTMs = new ATM[offices.Length];

            //foreach (string address in officePlaces)
            //{
            //    string query = $"https://geocode-maps.yandex.ru/1.x/?lang=ru_RU&apikey={apiKey}&geocode=text={}&format=json";
            //}
            return GetResponseAsync("Москва").Result;
        }

        private Office[] GetOffices()
        {
            List<string> officePlaces = new List<string>();
            OfficeArray officeArray = new OfficeArray();
            string OfficeFilePath = "D:\\cpp\\VTBproject\\VTBproject\\VTBproject\\Geolocator\\Data\\offices.json";
            //string OfficeFilePath = Path.Combine(AppContext.BaseDirectory, "offices.json");
            officeArray.GetListFromJson(File.ReadAllText(OfficeFilePath));
            return officeArray.Items;
        }
        private ATM[] GetATMs()
        {
            List<string> atmPlaces = new List<string>();
            string ATMFilePath = "D:\\cpp\\VTBproject\\VTBproject\\VTBproject\\Geolocator\\Data\\atms.json";
            ATMList aTMList = new ATMList();
            //string ATMFilePath = Path.Combine(AppContext.BaseDirectory, "atms.json");
            aTMList.GetListFromJson(File.ReadAllText(ATMFilePath));
            return aTMList.Items;
        }

        private string BuildUrl(string address)
        {
            var sb = new StringBuilder();
            sb.Append("http://geocode-maps.yandex.ru/2.1/?");
            sb.Append($"geocode={address}");
            sb.Append($"&lang=RU-ru");
            sb.Append($"&apikey={GeolocatorApiKey}");
            sb.Append("&format=json");
            return sb.ToString();
        }
        private async Task<string> GetResponseAsync(string address)
        {
            var url = BuildUrl(address);
            var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return response;
        }

        private void SaveLocation(string data)
        {
            
        }
    }
}
