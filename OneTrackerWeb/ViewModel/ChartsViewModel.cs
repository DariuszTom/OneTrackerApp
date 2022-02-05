using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.EFServices;
using DbDataLibrary.Models.Entities;
using SharedLibrary.Developer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public class ChartsViewModel : BaseViewModel<Project>
    {
        #region Fields

        private int _SelectedTeam;
        private SpecialCaseService caseService;
        private List<DevStats> _DevStats;

        #endregion Fields

        #region Properties

        public int SelectedTeam
        {
            get { return _SelectedTeam; }
            set => base.Set(ref _SelectedTeam, value);
        }

        public List<DevStats> DevStats
        {
            get { return _DevStats; }
            set => base.Set(ref _DevStats, value);
        }

        #endregion Properties

        #region Constructor

        public ChartsViewModel() : base()
        {
            ClearDevStats();
            base._title = "States Page";
            caseService = new();
        }

        #endregion Constructor

        #region Commands

        private AsyncCommand _GetDevStatsCommand;
        public AsyncCommand GetDevStatsCommand { get => _GetDevStatsCommand = new AsyncCommand(() => GetDevStats()); }

        #endregion Commands



        #region Overrited Methods

        public override async Task<List<Project>> LoadMainViewTable()
        {
            return await caseService.GetAllOpenProjects();
        }

        #endregion Overrited Methods

        #region Private Methods

        private async Task GetDevStats()
        {
            var team = await GetTeam(SelectedTeam);
            var projects = await LoadMainViewTable();

            if (team is null || projects is null) return;

            ClearDevStats();
            using (var perfomanceCheck = new FindFreeDeveloper(team))
            {
                perfomanceCheck.HowManyMonthPior = 12;
                DevStats = await perfomanceCheck.GetListOfDevStats(projects);
            }
            DevStats.Sort();
            Toaster.Add("Data Load", MatBlazor.MatToastType.Info);
        }

        private async Task<DevTeam> GetTeam(int? id)
        {
            if (id is null || id == 0)
            {
                Toaster.Add("Team not selected", MatBlazor.MatToastType.Warning);
                return null;
            }
            return await caseService.GetDevTeamById((int)id);
        }

        private void ClearDevStats()
        {
            DevStats item = new(9999);
            item.Score = 100;
            item.FullName = "Place Holder";
            DevStats = new() { item };
        }

        #endregion Private Methods
    }
}