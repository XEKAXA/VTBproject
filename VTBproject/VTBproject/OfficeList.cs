using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTBproject
{
    internal class OfficeArray
    {
        public Office[] Items;

        public void GetListFromJson(string jsonStr)
        {
            Items = JsonConvert.DeserializeObject<Office[]>(jsonStr);
        }

        public string ShowFirst5()
        {
            string result = "";
            for (int i = 0; i < 10; i++)
            {
                result += Items[i].Address + "|";
            }
            return result;
        }
    }
}
