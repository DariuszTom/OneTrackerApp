using DbDataLibrary.Mapper;
using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using MatBlazor;
using OneTrackerWeb.Services;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class TeamsViewModel : BaseViewModel<DevTeam>
    {
        #region Contructor

        public TeamsViewModel() : base()
        {
            base._title = "Teams Page";
            DbServiceStore = new TeamsDataStore();
        }

        #endregion Contructor

        #region Methods

        internal async Task ConvertAndAdd(TeamsDisplay teamDis)
        {
            bool result;
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                var teamMap = _MapperNew.Map<DevTeam>(teamDis);
                if (IsNew == true) result = await base.AddItemToDb(teamMap);
                else
                {
                    result = await base.UpdatetemToDb(teamMap);
                    base.ClearAfterEdit();
                }
            }
            if (result == true) Toaster.Add($"{ButtonTxt} to database team {teamDis.TeamName}", MatToastType.Success);
            else Toaster.Add($"Could not {ButtonTxt} to database team {teamDis.TeamName}", MatToastType.Warning);
        }

        #endregion Methods

        #region OverideMethods

        public override async Task<bool> DeletetemToDb()
        {
            bool result;
            result = await base.DeletetemToDb();
            if (result == true) Toaster.Add($"Deleted {WorkItem.TeamName}", MatToastType.Success);
            else Toaster.Add($"Could not deleted {WorkItem.TeamName}", MatToastType.Success);
            return result;
        }

        public async Task<TeamsDisplay> ConvertToDisplayClass(DevTeam team)
        {
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = await Task.Run(() => mpConfig.MyMapperConfig.CreateMapper());
                return _MapperNew.Map<TeamsDisplay>(team);
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