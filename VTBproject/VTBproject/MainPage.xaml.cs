
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
            var office = officeArray.GetOfficeWithParametrs(lb_AnswerFromGPT.Text);
            if (office != null) lb_AnswerFromGPT.Text = $"Нашёл офис {office.salePointName}, по адресу {office.Address}";
            else lb_AnswerFromGPT.Text += "К сожалению, не смог найти ничего по вашему запросу";
            button.IsEnabled = true;
            lb_AnswerFromGPT.IsVisible = true;
        }
        private void btn_WV_MapClicked(object sender, EventArgs e)
        {
            WV_Map.Source = File.ReadAllText("C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\map.html");
        }
        OfficeArray officeArray;
        ATMList aTMList;
        private void btn_LoadDataClicked(object sender, EventArgs e)
        {
            officeArray = new OfficeArray();
            aTMList = new ATMList();

            string OfficeFilePath = Path.Combine(System.AppContext.BaseDirectory, "offices.txt");
            string ATMFilePath = Path.Combine(System.AppContext.BaseDirectory, "atms.txt");
            OfficeFilePath = "C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\atms.txt";
            ATMFilePath = "C:\\More.Tech\\VTBproject\\VTBproject\\VTBproject\\Resources\\Data\\offices.txt";
            officeArray.GetListFromJson(File.ReadAllText(OfficeFilePath));
            aTMList.GetListFromJson(File.ReadAllText(ATMFilePath));
            lb_Offices.Text = aTMList.ShowFirst();
        }
    }
}