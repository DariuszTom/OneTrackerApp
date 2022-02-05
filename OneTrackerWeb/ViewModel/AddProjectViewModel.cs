using DbDataLibrary.EFServices;
using DbDataLibrary.Mapper;
using DbDataLibrary.Models.DisplayModel;
using DbDataLibrary.Models.Entities;
using MatBlazor;
using OneTrackerWeb.Services;
using SharedLibrary.Developer;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class AddProjectViewModel : BaseViewModel<Project>
    {
        #region Fields

        private string _FreeDev;

        #endregion Fields

        #region Properties

        public string FreeDev
        {
            get { return _FreeDev; }
            set => base.Set(ref _FreeDev, value);
        }

        #endregion Properties



        #region Constructor

        public AddProjectViewModel() : base()
        {
            base._title = "Create Project Page";
            DbServiceStore = new ProjectDataStore();
        }

        #endregion Constructor

        #region Methods

        internal async Task ConvertAndAdd(ProjectDisplay proDis)
        {
            bool result;
            using (var mpConfig = new DisplayMaperConfig())
            {
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                var provMap = _MapperNew.Map<Project>(proDis);
                if (IsNew == true) result = await base.AddItemToDb(provMap);
                else
                {
                    result = await base.UpdatetemToDb(provMap);
                    base.ClearAfterEdit();
                }
            }
            if (result == true) Toaster.Add($"{ButtonTxt} to database team {proDis.ProjectName}", MatToastType.Success);
            else Toaster.Add($"Could not {ButtonTxt} to database team {proDis.ProjectName}", MatToastType.Warning);
        }

        internal async Task<int?> FindFreeDev(int devteamId)
        {
            FreeDev = string.Empty;

            var specialService = new SpecialCaseService();
            var listOfPro = await specialService.GetAllOpenProjects();
            DevTeam team = await specialService.GetDevTeamById(devteamId);

            if (listOfPro.Count == 0 || team is null) return null;

            FindFreeDeveloper freeDev = new(team);
            var result = await freeDev.FindIdMostFreeDeveloperAsync(listOfPro);

            Toaster.Add($"Developer from team {team.TeamName} which have most time" +
                $" to work on request is {result.fullName}", MatToastType.Info);
            return result.id;
        }

        #endregion Methods
    }
}