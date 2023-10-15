using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace VTBproject
{
    internal class OfficeArray
    {
        public Office[] Items;

        public void GetListFromJson(string jsonStr)
        {
            Items = JsonConvert.DeserializeObject<Office[]>(jsonStr.Trim());
        }

        public Office GetOfficeWithParametrs(string parametr)
        {
            // Адрес, который вы ищете
            string[] parametrs = parametr.Split('|');
            string searchParameter = parametrs[2];
            string searchField = parametrs[0];

            var query = Items.Where(o => GetPropertyValue(o, searchField).ToString() == searchParameter);

            var office = query.FirstOrDefault();
            return office;
        }
        object GetPropertyValue(Office office, string propertyName)
        {
            var property = office.GetType().GetProperty(propertyName);
            if (property != null)
            {
                return property.GetValue(office);
            }
            return null;
        }
        public string ShowFirst5()
        {
            string result = "";
            result = $"1.{Items[0].salePointName}\n2.{Items[0].Address}\n3.{Items[0].Status}" +
                $"\n4.{Items[0].Rko}\n5.{Items[0].OfficeType}\n6.{Items[0].SalePointFormat}" +
                $"\n7.{Items[0].SuoAvailability}\n8.{Items[0].HasRamp}\n9.{Items[0].Latitude}" +
                $"\n10.{Items[0].Longitude}\n11.{Items[0].MetroStation}\n12.{Items[0].Distance}" +
                $"\n13.{Items[0].Kep}\n14.{Items[0].MyBranch}";
            /*for (int i = 0; i < 10; i++)
            {
                result += $"{Items[i].SalePointName}\n";
            }*/
            return result;
        }
    }
}
