using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public class TeamsDataStore : GenericDataStore<DevTeam>
    {
        #region Constructor

        public TeamsDataStore()
        {
            caseService = new();
        }

        #endregion Constructor

        #region Fields

        private readonly SpecialCaseService caseService;

        #endregion Fields

        #region OverideMethods

        public override async Task<List<DevTeam>> GetItemsAsync(bool forceRefresh = false)
        {
            return await caseService.GetDevTeam();
        }

        #endregion OverideMethods
    }
}