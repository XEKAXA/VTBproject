namespace VTBproject
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            OfficeArray officeArray = new OfficeArray();
            ATMList aTMList = new ATMList();

            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDirectory = Path.GetDirectoryName(exePath);
            Directory.SetCurrentDirectory(exeDirectory);

            string OfficeFilePath = Path.Combine(Directory.GetCurrentDirectory(), "offices.txt");
            string ATMFilePath = Path.Combine(Directory.GetCurrentDirectory(), "atms.txt");

            officeArray.GetListFromJson(File.ReadAllText(OfficeFilePath));
            aTMList.GetListFromJson(File.ReadAllText(ATMFilePath));

            CounterBtn.Text = aTMList.ShowFirst5();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}