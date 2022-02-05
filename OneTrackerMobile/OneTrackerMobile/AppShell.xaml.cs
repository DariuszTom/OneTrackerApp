using OneTrackerMobile.Views;
using SharedLibrary.Interfaces;
using System;
using Xamarin.Forms;

namespace OneTrackerMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            //Sprawdzamy czy urzadzenie posiada dostęp do internetu
            //Dependecy Injection dlatego ze na kazdej maszynie robi sie to innaczej
            INetworkManager mgr = DependencyService.Get<INetworkManager>();
            if (mgr == null || mgr.IsConnectedToNet() == false)
            {
                DisplayAlert("Error", "Device is not connected to internet" +
                             "That will make app not useble. App is going to close", "Ok");
            }

            InitializeComponent();
            RoutingConfig();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void RoutingConfig()
        {
            Routing.RegisterRoute(nameof(NewDepartmentPage), typeof(NewDepartmentPage));
            Routing.RegisterRoute(nameof(DepartmentsPage), typeof(DepartmentsPage));
            Routing.RegisterRoute(nameof(NewTeamPage), typeof(NewTeamPage));
            Routing.RegisterRoute(nameof(TeamsPage), typeof(TeamsPage));
            Routing.RegisterRoute(nameof(TitlePage), typeof(TitlePage));
            Routing.RegisterRoute(nameof(AppUserPage), typeof(AppUserPage));
            Routing.RegisterRoute(nameof(DevelopersPage), typeof(DevelopersPage));
            Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
            Routing.RegisterRoute(nameof(AllProjectsPage), typeof(AllProjectsPage));
        }
    }
}