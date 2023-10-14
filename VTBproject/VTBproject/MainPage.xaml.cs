using Microsoft.Maui.Maps;
using OpenAI_API.Models;
using OpenAI_API;
using System.Xml.Serialization;
using OpenAI_API.Chat;
using OpenAI_API.Moderation;
using OpenAI_API.Completions;

namespace VTBproject
{
    public partial class MainPage : ContentPage
    {
        GPTTalker gptTalker;
        public MainPage()
        {
            InitializeComponent();
            gptTalker = new GPTTalker();
            gptTalker.SetSettings();
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
            lb_AnswerFromGPT.Text = await gptTalker.Talk(entry_Request.Text);
            button.IsEnabled = true;
            lb_AnswerFromGPT.IsVisible = true;
        }
        private void btn_WV_MapClicked(object sender, EventArgs e)
        {
            WV_Map.Source = File.ReadAllText("C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\map.html");
        }
        private void btn_LoadDataClicked(object sender, EventArgs e)
        {
            OfficeArray officeArray = new OfficeArray();
            ATMList aTMList = new ATMList();

            string OfficeFilePath = Path.Combine(System.AppContext.BaseDirectory, "offices.txt");
            string ATMFilePath = Path.Combine(System.AppContext.BaseDirectory, "atms.txt");
            OfficeFilePath = "C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\atms.txt";
            ATMFilePath = "C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\offices.txt";
            officeArray.GetListFromJson(File.ReadAllText(OfficeFilePath));
            aTMList.GetListFromJson(File.ReadAllText(ATMFilePath));
        }
    }
}