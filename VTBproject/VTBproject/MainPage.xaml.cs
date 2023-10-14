using Microsoft.Maui.Maps;

namespace VTBproject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btn_LoadDataClicked(object sender, EventArgs e)
        {
            OfficeArray officeArray = new OfficeArray();
            ATMList aTMList = new ATMList();

            string OfficeFilePath = Path.Combine(System.AppContext.BaseDirectory, "offices.txt");
            string ATMFilePath = Path.Combine(System.AppContext.BaseDirectory, "atms.txt");

            officeArray.GetListFromJson(File.ReadAllText(OfficeFilePath));
            aTMList.GetListFromJson(File.ReadAllText(ATMFilePath));
        }
    }
}