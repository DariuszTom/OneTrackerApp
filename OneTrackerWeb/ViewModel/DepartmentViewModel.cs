using DbDataLibrary.Mapper;
using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using MatBlazor;
using OneTrackerWeb.Services;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class DepartmentViewModel : BaseViewModel<Department>
    {
        #region Contructor

        public DepartmentViewModel() : base()
        {
            base._title = "Department Page";
            DbServiceStore = new GenericDataStore<Department>();
        }

        #endregion Contructor

        #region Methods

        internal async Task ConvertAndAdd(DepartmentDisplay depDis)
        {
            bool result;
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                var depMap = _MapperNew.Map<Department>(depDis);
                result = await base.AddItemToDb(depMap);
            }
            if (result == true) Toaster.Add($"Added to database departament {depDis.DepName}", MatToastType.Success);
            else Toaster.Add($"Could not added to database departament {depDis.DepName}", MatToastType.Warning);
        }

        #endregion Methods

        #region OverideMethods

        public override async Task<bool> DeletetemToDb()
        {
            bool result;
            result = await base.DeletetemToDb();
            if (result == true) Toaster.Add($"Deleted {WorkItem.DepName}", MatToastType.Success);
            else Toaster.Add($"Could not deleted {WorkItem.DepName}", MatToastType.Success);
            return result;
        }

        #endregion OverideMethods
    }
}