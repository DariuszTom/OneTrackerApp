using DbDataLibrary.Mapper;
using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using MatBlazor;
using OneTrackerWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class DevelopersViewModel : BaseViewModel<Employee>
    {
        #region Fields

        private IList<string> _Positions;

        #endregion Fields

        #region Properties

        public IList<string> Positions
        {
            get
            {
                if (_Positions is null)
                    Positions = new List<string>()
                    { "A1", "A2", "SA","Off","AVP" };
                return _Positions;
            }

            set => _Positions = value;
        }

        #endregion Properties

        #region Contructor

        public DevelopersViewModel() : base()
        {
            base._title = "Developer Page";
            DbServiceStore = new DevelopersDataStore();
        }

        #endregion Contructor

        #region Methods

        internal async Task ConvertAndAdd(DevelopertDisplay devDis)
        {
            bool result;
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                var devMap = _MapperNew.Map<Employee>(devDis);
                if (IsNew == true) result = await base.AddItemToDb(devMap);
                else
                {
                    result = await base.UpdatetemToDb(devMap);
                    base.ClearAfterEdit();
                }
            }
            if (result == true) Toaster.Add($"{ButtonTxt} to database team {devDis.IdEmployee}", MatToastType.Success);
            else Toaster.Add($"Could not {ButtonTxt} to database team {devDis.IdEmployee}", MatToastType.Warning);
        }

        #endregion Methods

        #region OverideMethods

        public override async Task<bool> DeletetemToDb()
        {
            bool result;
            result = await base.DeletetemToDb();
            if (result == true) Toaster.Add($"Deleted {WorkItem.IdEmployee}", MatToastType.Success);
            else Toaster.Add($"Could not deleted {WorkItem.IdEmployee}", MatToastType.Success);
            return result;
        }

        public async Task<DevelopertDisplay> ConvertToDisplayClass(Employee dev)
        {
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = await Task.Run(() => mpConfig.MyMapperConfig.CreateMapper());
                return _MapperNew.Map<DevelopertDisplay>(dev);
            }
        }

        public override void ClearAfterEdit()
        {
            WorkItem = new();
            base.ClearAfterEdit();
        }

        #endregion OverideMethods
    }
}