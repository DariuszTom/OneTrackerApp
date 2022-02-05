using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.Models.Entities;
using MatBlazor;
using OneTrackerWeb.Services;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class OpenProjectViewModel : BaseViewModel<Project>
    {
        #region Commands

        private AsyncCommand _UpdateItemCommand;
        public AsyncCommand UpdateItemCommand { get => _UpdateItemCommand = new AsyncCommand(() => UpdateProjectInDb()); }

        #endregion Commands

        #region Constructor

        public OpenProjectViewModel() : base()
        {
            base._title = "Open Projects Page";
            DbServiceStore = new ProjectDataStore();
        }

        #endregion Constructor

        #region Methods

        private async Task UpdateProjectInDb()
        {
            if (WorkItem is null) return;
            if (WorkItem.DevTeam is null || WorkItem.DevTeam == 0) WorkItem.DevTeamNavigation = null;
            if (WorkItem.Developer is null || WorkItem.Developer == 0) WorkItem.DeveloperNavigation = null;

            int workId = WorkItem.Id;
            bool result = await base.UpdatetemToDb();

            if (result == true) Toaster.Add($"Updated to database project {workId}", MatToastType.Success);
            else Toaster.Add($"Could not Updated to database team {workId}", MatToastType.Warning);
        }

        #endregion Methods

        #region Overrides

        public override async Task<bool> DeletetemToDb()
        {
            bool result;
            result = await base.DeletetemToDb();
            if (result == true) Toaster.Add($"Deleted {WorkItem.Id}", MatToastType.Success);
            else Toaster.Add($"Could not deleted {WorkItem.Id}", MatToastType.Success);
            return result;
        }

        #endregion Overrides
    }
}