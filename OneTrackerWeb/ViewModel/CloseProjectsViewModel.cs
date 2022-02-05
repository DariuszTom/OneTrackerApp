using DbDataLibrary.Models.Entities;
using OneTrackerWeb.Services;

namespace OneTrackerWeb.ViewModel
{
    public class CloseProjectsViewModel : BaseViewModel<ProjectFinalized>
    {
        #region Constructor

        public CloseProjectsViewModel() : base()
        {
            base._title = "Close Projects Page";
            DbServiceStore = new CloseProjectsDataStore();
        }

        #endregion Constructor
    }
}