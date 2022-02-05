using AsyncAwaitBestPractices.MVVM;
using OneTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands

        private AsyncCommand _LoginCommandAsync;
        public AsyncCommand LoginCommandAsync { get => _LoginCommandAsync = new AsyncCommand(() => OnLoginClickedAsync()); }

        #endregion Commands

        public LoginViewModel()
        {
        }

        #region Fields

        private string _CompanyID;
        private int _AppID;
        private string _LoginMessage;

        #endregion Fields

        #region Properties

        public string CompanyID
        {
            get { return _CompanyID; }
            set
            {
                _CompanyID = value;
                OnPropertyChanged(() => CompanyID);
            }
        }

        public string LoginMessage
        {
            get { return _LoginMessage; }
            set
            {
                _LoginMessage = value;
                OnPropertyChanged(() => LoginMessage);
            }
        }

        public int AppID
        {
            get { return _AppID; }
            set
            {
                _AppID = value;
                OnPropertyChanged(() => CompanyID);
            }
        }

        #endregion Properties

        private async Task OnLoginClickedAsync()
        {
            LoginMessage = string.Empty;
            //var host = new OneTrackerDbService.OneTrackerDbServiceClient();
            //if (await Task.Run(() => !host.UserInDB(AppID)))
            //{
            //    LoginMessage = $"Id {AppID} and {CompanyID} not find in database. Try one more time or create new user";
            //    return;
            //}
            //await base.ShowMsgBox("Logged successfully", "Loggin");
            await Shell.Current.GoToAsync($"//{nameof(TitlePage)}");
        }
    }
}