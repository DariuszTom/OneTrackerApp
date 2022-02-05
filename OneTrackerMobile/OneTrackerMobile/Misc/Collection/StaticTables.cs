using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using OneTrackerDbService;
using SharedLibrary.Developer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.Misc.Collection
{
    public class StaticTables
    {
        #region Singleton
        private static readonly Lazy<StaticTables> lazy =
        new Lazy<StaticTables>(() => new StaticTables());
        public static StaticTables GetInstance { get { return lazy.Value; } }
        private StaticTables()
        {
            DbService = DependencyService.Get<IOneTrackerDbService>();
        }
        #endregion
        #region Fields
        protected IOneTrackerDbService DbService { get; set; }
        private List<ProjectStatus> _ProjectStatuses;
        private List<ProjectType> _ProjectTypes;
        private List<ProjectPriority> _ProjectPriority;
        private List<TeamForViewNew> _TeamForView;
        private List<DeveloperForView> _DevelopersForView;
        #endregion
        #region Properties
        public List<DeveloperForView> DevelopersForView
        {
            get
            {
                if (_DevelopersForView is null) LoadDevelopersModel();
                return _DevelopersForView;
            }
            set { _DevelopersForView = value; }
        }

        public List<TeamForViewNew> TeamForView
        {
            get
            {
                if (_TeamForView is null) LoadTeamModel();
                return _TeamForView;
            }
            set { _TeamForView = value; }
        }
        public List<string> PriorityStr => new List<string>()
                   { "Low", "Mid", "High","Critical" };
        public List<ProjectType> ProjectTypes
        {
            get
            {
                if (_ProjectTypes is null) LoadTypes();
                return _ProjectTypes;
            }
            set { _ProjectTypes = value; }
        }
        public List<ProjectStatus> ProjectStatuses
        {
            get
            {
                if (_ProjectStatuses is null) LoadStatus();
                return _ProjectStatuses;
            }
            set { _ProjectStatuses = value; }
        }
        public List<ProjectPriority> ProjectPriority
        {
            get
            {
                if (_ProjectPriority is null) LoadPriority();
                return _ProjectPriority;
            }
            set { _ProjectPriority = value; }
        }

        #endregion

        #region Methods
        private void LoadPriority()
        {
            ProjectPriority = new List<ProjectPriority>();
            ProjectPriority = new List<ProjectPriority>(DbService.GetAllProjectPriorityRecords());
        }

        private void LoadStatus()
        {
            ProjectStatuses = new List<ProjectStatus>();
            ProjectStatuses = new List<ProjectStatus>(DbService.GetAllProjectStatusRecords());
        }

        private void LoadTypes()
        {
            ProjectTypes = new List<ProjectType>();
            ProjectTypes = new List<ProjectType>(DbService.GetAllProjectTypesRecords());
        }
        private void LoadDevelopersModel()
        {
            DevelopersForView = new List<DeveloperForView>();
            DevelopersForView = new List<DeveloperForView>(DbService.GetAllDevelopersRecords());
        }
        private void LoadTeamModel()
        {
            TeamForView = new List<TeamForViewNew>();
            TeamForView = new List<TeamForViewNew>(DbService.GetAllTeamForViewRecords());
        }
        public async Task<List<DevStats>> ImportDevStats(int devTeamId)
        {
            return new List<DevStats>(await Task.Run(() => DbService.GetDevStats(devTeamId)));
        }
        #endregion
    }
}
