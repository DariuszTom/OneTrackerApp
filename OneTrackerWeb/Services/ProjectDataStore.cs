using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public class ProjectDataStore : GenericDataStore<Project>
    {
        #region Constructor

        public ProjectDataStore()
        {
            caseService = new();
        }

        #endregion Constructor

        #region Fields

        private readonly SpecialCaseService caseService;

        #endregion Fields

        #region OverideMethods

        public override async Task<List<Project>> GetItemsAsync(bool forceRefresh = false)
        {
            return await caseService.GetAllOpenProjects();
        }

        #endregion OverideMethods
    }
}