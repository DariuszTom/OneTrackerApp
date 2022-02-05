using DbDataLibrary.Models.Entities;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using OneTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class DepartamentsViewModel : AllViewModel<Department>
    {
        #region Constructor

        public DepartamentsViewModel() : base()
        {
            base.Title = "Departaments";
            Task.Run(() => base.LoadMainViewTable());
        }

        #endregion Constructor



        #region Methods

        public override async Task OnNewItem()
        {
            await Shell.Current.GoToAsync(nameof(NewDepartmentPage));
        }

        #endregion Methods
    }
}