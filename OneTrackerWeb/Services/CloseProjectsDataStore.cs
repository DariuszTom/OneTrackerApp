using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public class CloseProjectsDataStore : GenericDataStore<ProjectFinalized>
    {
        #region Constructor

        public CloseProjectsDataStore()
        {
            caseService = new();
        }

        #endregion Constructor

        #region Fields

        private readonly SpecialCaseService caseService;

        #endregion Fields

        #region OverideMethods

        public override async Task<List<ProjectFinalized>> GetItemsAsync(bool forceRefresh = false)
        {
            return await caseService.GetAllCloseProjects();
        }

        #endregion OverideMethods
    }
}