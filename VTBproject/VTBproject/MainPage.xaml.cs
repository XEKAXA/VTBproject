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
            string currentDirectory = Directory.GetCurrentDirectory();
            string relativeFilePath = Path.Combine(currentDirectory, "atms.txt");

            aTMList.GetListFromJson(File.ReadAllText(relativeFilePath));

            CounterBtn.Text = aTMList.ShowFirst5();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}