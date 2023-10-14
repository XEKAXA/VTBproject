// See https://aka.ms/new-console-template for more information
using Yandex.Geocoder;

string API_KEY = "d46a2c82-1946-465d-a02c-b84e80ca528e";

var geocoder = new YandexGeocoder
{
    Apikey = API_KEY,
    SearchQuery = "Зейский государственный природный заповедник",
    Results = 1,
    LanguageCode = LanguageCode.ru_RU
};

var results = geocoder.GetResults();
foreach (var result in results)
    Console.WriteLine(result.ToString());