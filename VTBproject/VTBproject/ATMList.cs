using Newtonsoft.Json;

namespace VTBproject
{
    internal class ATMList
    {
        public List<ATM> Items;

        public void GetListFromJson(string jsonStr)
        {
            Items = JsonConvert.DeserializeObject<List<ATM>>(jsonStr);
        }
        public ATM GetATMWithParametrs(string parametr)
        {
            // Адрес, который вы ищете
            string[] parametrs = parametr.Split('|');
            string searchParameter = parametrs[2];
            string searchField = parametrs[0];

            var query = Items.Where(o => o.Address.Contains(searchParameter));

            var atm = query.FirstOrDefault();
            return atm;
        }
        object GetPropertyValue(ATM atm, string propertyName)
        {
            var property = atm.GetType().GetProperty(propertyName);
            if (property != null)
            {
                return property.GetValue(atm);
            }
            return null;
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
