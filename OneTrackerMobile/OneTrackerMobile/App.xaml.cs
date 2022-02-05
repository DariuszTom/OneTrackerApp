using OneTrackerDbService;
using OneTrackerMobile.Services;
using Xamarin.Forms;

namespace OneTrackerMobile
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YourCode");

            MainPage = new AppShell();
            RegisterServices();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterServices()
        {
            DependencyService.Register<DepartamentsDataStore>();
            DependencyService.Register<TeamsDataStore>();
            DependencyService.Register<TeamsViewDataStore>();
            DependencyService.Register<UserDataStore>();
            DependencyService.Register<DevelopersViewDataStore>();
            DependencyService.Register<ProjectDataStore>();
            DependencyService.Register<OneTrackerDbServiceClient>();
        }
    }
}