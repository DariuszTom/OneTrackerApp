using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace OneTrackerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppUserPage : ContentPage
    {
        public AppUserPage()
        {
            InitializeComponent();
            Task.Run(() => ShowSnackBar());
        }

        private async Task ShowSnackBar()
        {
            await MaterialDialog.Instance.SnackbarAsync(message: "Trying to load your data",
                                            msDuration: MaterialSnackbar.DurationShort);
        }
    }
}