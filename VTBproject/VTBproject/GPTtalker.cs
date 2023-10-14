using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VTBproject
{
    public class GPTTalker
    {
        private readonly string _apiKey;
        private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";

        public GPTTalker(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> GenerateResponse(string prompt)
        {
            string requestBody = $"{{\"prompt\": \"{prompt}\", \"max_tokens\": 150}}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
                HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(_apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception($"Ошибка при выполнении запроса к API. Код состояния: {response.StatusCode}");
                }
            }
        }
    }
}
