using Yandex.Geocoder;

namespace VTBproject
{
    internal class YandexAPI
    {
        YandexGeocoder geocoder;
        public YandexAPI()
        {
            string API_KEY = "d46a2c82-1946-465d-a02c-b84e80ca528e";

            geocoder = new YandexGeocoder
            {
                Apikey = API_KEY,
                SearchQuery = "Зейский государственный природный заповедник",
                Results = 1,
                LanguageCode = LanguageCode.ru_RU
            };
        }
        public string GetResult()
        {
            string answer = string.Empty;
            var results = geocoder.GetResults();
            foreach (var result in results)
                answer += result.ToString();
            return answer;
        }
    }
}
