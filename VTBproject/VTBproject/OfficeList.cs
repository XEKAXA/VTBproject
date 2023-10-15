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
    internal class OfficeList
    {
        public List<Office> Items;

        public void GetListFromJson(string jsonStr)
        {
            Items = JsonConvert.DeserializeObject<List<Office>>(jsonStr);
        }

        public Office GetOfficeWithParametrs(string parametr)
        {
            // Адрес, который вы ищете
            string[] parametrs = parametr.Split('|');
            string searchParameter = parametrs[2];
            string searchField = parametrs[0];

            var query = Items.Where(o => o.Address.Contains(searchParameter));

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
        public string ShowFirst()
        {
            string result = "";
            result = JsonConvert.SerializeObject(Items[0]);
            return result;
        }
    }
}
