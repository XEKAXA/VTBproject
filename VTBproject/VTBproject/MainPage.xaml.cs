using Microsoft.Maui.Maps;
using OpenAI_API.Models;
using OpenAI_API;
using System.Xml.Serialization;
using OpenAI_API.Chat;
using OpenAI_API.Moderation;
using VTBproject.Geolocator;

namespace VTBproject
{
    public partial class MainPage : ContentPage
    {
        GPTTalker gptTalker;
        public MainPage()
        {
            InitializeComponent();
        }
        private void btn_GPTVisibleClicked(object sender, EventArgs e)
        {
            frame_GPT.IsVisible = true;
        }
        private void btn_ReturnClicked(object sender, EventArgs e)
        {
            frame_GPT.IsVisible = false;
        }

        private async void btn_AskGPTClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            var api = new OpenAI_API.OpenAIAPI("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");
            string result = string.Empty;
            var chat = api.Chat.CreateConversation();
            chat.AppendUserInput(entry_Request.Text);

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                result += res;
            }
            lb_AnswerFromGPT.Text = result;
            button.IsEnabled = true;
        }
        private void btn_WV_MapClicked(object sender, EventArgs e)
        {
            WV_Map.Source = File.ReadAllText("C:\\More.Tech\\VTBproject\\VTBproject\\Resources\\Data\\map.html");
        }
        private async void btn_LoadDataClicked(object sender, EventArgs e)
        {
            Locator locator = new Locator();
            string s = await GetCurrentLocation();
            var k = s;
        }

        public async Task<string> GetCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location == null)
                {
                    return "Something went wrong. Cannot get your location.";
                }
                else
                {
                    return $"My Latitude and Longtidue: {location.Latitude}, {location.Longitude}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Err";
        }

    }
}