using DbDataLibrary.EFServices;
using DbDataLibrary.Mapper;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace DbDataLibrary.GroupCollection
{
    [DataContract]
    public sealed class DictionaryTables : INotifyPropertyChanged
    {
        /// <summary>
        /// Klasa Słownikowa przechowująca tabele z bazy danych ktore rzadka sie zmieniaja
        /// ale czesto doniej sa odwolania
        /// </summary>

        #region Constructor

        private DictionaryTables()
        {
        }

        private static DictionaryTables instance = null;

        public static DictionaryTables Instance
        {
            get
            {
                if (instance == null) instance = new DictionaryTables();

                return instance;
            }
        }

        #endregion Constructor

        #region Fields

        private List<ProjectStatus> _ProjectStatuses;
        private List<ProjectType> _ProjectTypes;
        private List<ProjectPriority> _ProjectPriority;
        private List<Department> _Departments;
        private List<DevTeam> _DevTeams;
        private List<Employee> _Developers;
        private List<Project> _OpenProjects;
        private List<TeamForViewNew> _TeamForView;
        private List<DeveloperForView> _DevelopersForView;

        #endregion Fields

        #region Properties

        public List<ProjectForView> OpenProjectsForView
        {
            get => LoadProjectsForView();
        }

        public List<Project> OpenProjects
        {
            get
            {
                LoadProjects();
                return _OpenProjects;
            }
            set { _OpenProjects = value; }
        }

        public List<DeveloperForView> DevelopersForView
        {
            get
            {
                LoadDevelopersModel();
                return _DevelopersForView;
            }
            set { _DevelopersForView = value; }
        }

        public List<TeamForViewNew> TeamForView
        {
            get
            {
                LoadTeamModel();
                return _TeamForView;
            }
            set { _TeamForView = value; NotifyPropertyChanged(); }
        }

        public List<Employee> Developers
        {
            get
            {
                LoadDevelopers();
                return _Developers;
            }
            set { _Developers = value; NotifyPropertyChanged(); }
        }

        public List<Department> Departments
        {
            get
            {
                LoadDepartments();
                return _Departments;
            }
            set { _Departments = value; NotifyPropertyChanged(); }
        }

        public List<DevTeam> DevTeams
        {
            get
            {
                LoadDevTeams();
                return _DevTeams;
            }
            set { _DevTeams = value; NotifyPropertyChanged(); }
        }

        public List<ProjectType> ProjectTypes
        {
            get
            {
                if (_ProjectTypes is null) LoadTypes();
                return _ProjectTypes;
            }
            set { _ProjectTypes = value; NotifyPropertyChanged(); }
        }

        public List<ProjectPriority> ProjectPriority
        {
            get
            {
                if (_ProjectPriority is null) LoadPriority();
                return _ProjectPriority;
            }
            set { _ProjectPriority = value; NotifyPropertyChanged(); }
        }

        public List<ProjectStatus> ProjectStatuses
        {
            get
            {
                if (_ProjectStatuses is null) LoadStatus();
                return _ProjectStatuses;
            }
            set { _ProjectStatuses = value; NotifyPropertyChanged(); }
        }

        #endregion Properties

        #region Methods

        private void LoadProjects()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                OpenProjects = new List<Project>(OneTrackerContext.Project);
            }
        }

        private void LoadDevelopers()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                Developers = new List<Employee>(OneTrackerContext.Employee);
            }
        }

        private void LoadDepartments()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                Departments = new List<Department>(OneTrackerContext.Department);
            }
        }

        private void LoadDevTeams()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                DevTeams = new List<DevTeam>(OneTrackerContext.DevTeam);
                //.Include(d => d.DepartamentNavigation)
            };
        }

        private void LoadStatus()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                ProjectStatuses = new List<ProjectStatus>(OneTrackerContext.ProjectStatus);
            }
        }

        private void LoadTypes()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                ProjectTypes = new List<ProjectType>(OneTrackerContext.ProjectType);
            }
        }

        private void LoadPriority()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                ProjectPriority = new List<ProjectPriority>(OneTrackerContext.ProjectPriority);
            }
        }

        private void LoadTeamModel()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                var mpConfig = new AutoMaperConfig();
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                TeamForView = _MapperNew.ProjectTo<TeamForViewNew>(OneTrackerContext.DevTeam).ToList();
            }
        }

        private void LoadDevelopersModel()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                var mpConfig = new AutoMaperConfig();
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                _DevelopersForView = _MapperNew.ProjectTo<DeveloperForView>(OneTrackerContext.Employee
                    .Include(t => t.TeamNavigation)).ToList();
            }
        }

        private List<ProjectForView> LoadProjectsForView()
        {
            using (var mpConfig = new AutoMaperConfig())
            {
                var _MapperNew = mpConfig.MyMapperConfig.CreateMapper();
                var dbService = new SpecialCaseService();
                var result = dbService.GetAllOpenProjects().GetAwaiter().GetResult();
                return _MapperNew.Map<List<ProjectForView>>(result);
            }
        }

        #endregion Methods

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        #endregion Events
    }
}