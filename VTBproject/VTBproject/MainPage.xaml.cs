using System.Reflection;

namespace VTBproject
{
    public partial class MainPage : ContentPage
    {
        GPTTalker gptTalker;
        public MainPage()
        {
            InitializeComponent();
            LoadData();
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
            try
            {
                Button button = (Button)sender;
                button.IsEnabled = false;
                if (lb_AnswerFromGPT.Text != string.Empty)
                {
                    lb_AnswerFromGPT.Text = await gptTalker.Talk(entry_Request.Text);
                    /*string[] answer = lb_AnswerFromGPT.Text.Split('%');
                    ATM atm = null;
                    Office office = null;
                    switch (answer[0])
                    {
                        case "ATM":
                            {
                                atm = aTMList.GetATMWithParametrs(answer[1]);
                                break;
                            }
                        case "office":
                            {
                                office = officeList.GetOfficeWithParametrs(answer[1]);
                                break;
                            }
                        default:
                            {
                                lb_AnswerFromGPT.Text = answer[0];
                                return;
                            }
                    }
                    if (atm != null) lb_AnswerFromGPT.Text = $"Нашёл банкомат по адресу {atm.Address}, ({atm.Longitude},{atm.Latitude})";
                    else if (office != null) lb_AnswerFromGPT.Text = $"Нашёл офис {office.SalePointName} по адресу {office.Address}, ({office.Longitude},{office.Latitude})";
                    else lb_AnswerFromGPT.Text += "К сожалению, не смог найти ничего по вашему запросу";
                    */
                    
                }
                button.IsEnabled = true;
                lb_AnswerFromGPT.IsVisible = true;
            }
            catch (Exception ex) 
            {

            }
        }
        OfficeList officeList;
        ATMList aTMList;
        private void LoadData()
        {
            var offices = "VTBproject.Resources.Data.offices.txt";
            var content = "";
            var assembly = this.GetType().Assembly;
            using (var stream = assembly.GetManifestResourceStream(offices))
            {
                if (stream != null)
                {
                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                        officeList = new OfficeList();
                        btn_AskGPT.Text = content;
                        officeList.GetListFromJson(content);
                    }
                }
            }
            

            var atms = "VTBproject.Resources.Data.atms.txt";
            content = "";
            assembly = this.GetType().Assembly;
            using (var stream = assembly.GetManifestResourceStream(atms))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                        aTMList = new ATMList();
                        aTMList.GetListFromJson(content);
                    }
                }
            }
            
        }
    }
}
