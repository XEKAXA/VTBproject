using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTBproject.Properties;

namespace VTBproject
{
    internal class ATMList
    {
        public List<ATM> Items;

        public void GetListFromJson(string jsonStr)
        {
            Items = JsonConvert.DeserializeObject<List<ATM>>(jsonStr);
        }

        public string ShowFirst()
        {
            string result = "";
            result = $"1. {Items[0].Address}\n2. {Items[0].Latitude}\n3. {Items[0].Longitude}\n4. {Items[0].AllDay}\n5. {Items[0].AvailableServices.Wheelchair.ServiceActivity}" +
                $"\n6. {Items[0].AvailableServices.Blind.ServiceActivity}\n7. {Items[0].AvailableServices.NfcForBankCards.ServiceActivity}\n8. {Items[0].AvailableServices.SupportsChargeRub.ServiceActivity}\n9. {Items[0].AvailableServices.SupportsRub.ServiceActivity}";
            return result;
        }
    }
}
