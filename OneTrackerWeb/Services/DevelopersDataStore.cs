using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public class DevelopersDataStore : GenericDataStore<Employee>
    {
        #region Constructor

        public DevelopersDataStore()
        {
            caseService = new();
        }

        #endregion Constructor

        #region Fields

        private readonly SpecialCaseService caseService;

        #endregion Fields

        #region OverideMethods

        public override async Task<List<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            return await caseService.GetAllEmployee();
        }

        #endregion OverideMethods
    }
}