using DbDataLibrary.Database;
using DbDataLibrary.EFServices;
using DbDataLibrary.GroupCollection;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using SharedLibrary.Developer;
using System.Collections.Generic;

namespace OneTrackerDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OneTrackerDbService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OneTrackerDbService.svc or OneTrackerDbService.svc.cs at the Solution Explorer and start debugging.
    public partial class OneTrackerDbService : IOneTrackerDbService
    {
        #region Testing

        /// <summary>
        /// Testing If service is ready to opearate
        /// </summary>
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool DataBaseExists()
        {
            var connChecker = new ConnectionChecker();
            bool isError = connChecker.CouldConnect();
            return !isError;
        }

        #endregion Testing

        #region ReturnTable

        /// <summary>
        /// Returns list of records from table
        /// </summary>
        public List<Employee> GetAllEmployeeRecords() => DictionaryTables.Instance.Developers;

        public List<DeveloperForView> GetAllDevelopersRecords() => DictionaryTables.Instance.DevelopersForView;

        public List<DevTeam> GetAllDevTeamsRecords() => DictionaryTables.Instance.DevTeams;

        public List<TeamForViewNew> GetAllTeamForViewRecords() => DictionaryTables.Instance.TeamForView;

        public List<Department> GetAllDepartmentsRecords() => DictionaryTables.Instance.Departments;

        public List<ProjectStatus> GetAllProjectStatusRecords() => DictionaryTables.Instance.ProjectStatuses;

        public List<ProjectType> GetAllProjectTypesRecords() => DictionaryTables.Instance.ProjectTypes;

        public List<ProjectPriority> GetAllProjectPriorityRecords() => DictionaryTables.Instance.ProjectPriority;

        public List<Project> GetAllOpenProjects() => DictionaryTables.Instance.OpenProjects;

        public List<ProjectForView> GetOpenProjectsWithNavigation() => DictionaryTables.Instance.OpenProjectsForView;

        public List<DevStats> GetDevStats(int teamId)
        {
            using (var statsHelper = new DeveloperStatsHelper(teamId))
            {
                return statsHelper.GetDevStats().GetAwaiter().GetResult();
            }
        }

        #endregion ReturnTable

        #region Employee

        public Employee GetUserByHisCompanyId(string comId)
        {
            var dbService = new SpecialCaseService();
            return dbService.GetUserByCompanyId(comId);
        }

        public Employee GetUserByHisId(int id)
        {
            var dbService = new SpecialCaseService();
            return dbService.GetUserByIdAsync(id).GetAwaiter().GetResult();
        }

        public bool TryAddEmployeeToDB(Employee entity)
        {
            var dbService = new DbService<Employee>();
            return dbService.AddRecord(entity);
        }

        public bool TryEditEmployeeInDB(Employee entity)
        {
            var dbService = new DbService<Employee>();
            return dbService.UpdataAsync(entity).GetAwaiter().GetResult();
        }

        public bool TryDeleteEmployeeInDB(Employee entity)
        {
            var dbService = new DbService<Employee>();
            return dbService.Delete(entity);
        }

        #endregion Employee

        #region ProjectOpen

        public bool TryAddProjectToDB(Project entity)
        {
            var dbService = new SpecialCaseService();
            return dbService.AddProject(entity).GetAwaiter().GetResult();
        }

        public bool TryEditProjectInDB(Project entity)
        {
            var dbService = new DbService<Project>();
            return dbService.UpdataAsync(entity).GetAwaiter().GetResult();
        }

        public bool TryDeleteProjectInDB(Project entity)
        {
            var dbService = new DbService<Project>();
            return dbService.Delete(entity);
        }

        #endregion ProjectOpen

        #region DatabaseMethods

        public bool TryAddDepartmentToDB(Department entity)
        {
            var dbService = new DbService<Department>();
            return dbService.AddRecord(entity);
        }

        public bool TryAddDevTeamToDB(DevTeam team)
        {
            var dbService = new DbService<DevTeam>();
            return dbService.AddRecord(team);
        }

        public bool TryDeleteDevTeamFromDB(DevTeam team)
        {
            var dbService = new DbService<DevTeam>();
            return dbService.Delete(team);
        }

        public bool TryDeleteDevTeamFromDBbyId(int teamId)
        {
            var dbService = new DbService<DevTeam>();
            return dbService.Delete(teamId);
        }

        public bool TryEditDevTeamFromDB(DevTeam team)
        {
            var dbService = new DbService<DevTeam>();
            return dbService.UpdataAsync(team).GetAwaiter().GetResult();
        }

        #endregion DatabaseMethods
    }
}