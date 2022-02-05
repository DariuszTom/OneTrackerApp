using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.Models.Entities;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using OneTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class AllProjectsViewModel : AllViewModel<Project>
    {
        #region Constructor

        public AllProjectsViewModel() : base()
        {
            base.Title = "Open Projects";
            Task.Run(() => base.LoadMainViewTable());
        }

        #endregion Constructor



        #region Commands
        private AsyncCommand<Project> _ItemDetailsCommand;
        public AsyncCommand<Project> ItemDetailsCommand { get => _ItemDetailsCommand = new AsyncCommand<Project>((obj) => ItemDetails(obj)); }
        private AsyncCommand<Project> _EditItem;
        public AsyncCommand<Project> EditItem { get => _EditItem = new AsyncCommand<Project>((obj) => EditProject(obj)); }

        #endregion Commands

        #region Methods

        private async Task EditProject(Project pro)
        {
            if (pro is null) return;
            var addPage = new ProjectPage
            {
                BindingContext = new ProjectViewModel(pro)
            };
            await Shell.Current.Navigation.PushAsync(addPage);
        }

        private async Task ItemDetails(Project pro)
        {
            if (pro is null) return;
            var addPage = new ProjectDetailsPage
            {
                BindingContext = new ProjectDetailsViewModel(pro)
            };
            try
            {
                await Shell.Current.Navigation.PushAsync(addPage);
            }
            catch (System.Exception err)
            {


                throw;
            }
            
        }

        #endregion Methods

        #region Overide Methods

        public override Task OnNewItem()
        {
            throw new System.NotImplementedException();
        }

        #endregion Overide Methods
    }
}