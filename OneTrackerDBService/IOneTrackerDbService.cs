using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using SharedLibrary.Developer;
using System.Collections.Generic;
using System.ServiceModel;

namespace OneTrackerDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOneTrackerDbService
    {
        [OperationContract]

        #region CheckService

        string GetData(int value);

        [OperationContract]
        bool DataBaseExists();

        #endregion CheckService

        // All records

        #region AllRecords

        [OperationContract]
        List<Employee> GetAllEmployeeRecords();

        [OperationContract]
        List<DevTeam> GetAllDevTeamsRecords();

        [OperationContract]
        List<TeamForViewNew> GetAllTeamForViewRecords();

        [OperationContract]
        List<Department> GetAllDepartmentsRecords();

        [OperationContract]
        List<ProjectStatus> GetAllProjectStatusRecords();

        [OperationContract]
        List<ProjectType> GetAllProjectTypesRecords();

        [OperationContract]
        List<ProjectPriority> GetAllProjectPriorityRecords();

        [OperationContract]
        List<DeveloperForView> GetAllDevelopersRecords();

        [OperationContract]
        List<Project> GetAllOpenProjects();

        [OperationContract]
        List<ProjectForView> GetOpenProjectsWithNavigation();

        [OperationContract]
        List<DevStats> GetDevStats(int teamId);

        #endregion AllRecords

        /// <summary>
        /// /Crud on DataBase
        /// </summary>

        #region CrudDB

        [OperationContract]
        bool TryAddDepartmentToDB(Department entity);

        [OperationContract]
        bool TryAddDevTeamToDB(DevTeam team);

        [OperationContract]
        bool TryDeleteDevTeamFromDBbyId(int teamId);

        [OperationContract]
        bool TryDeleteDevTeamFromDB(DevTeam team);

        [OperationContract]
        bool TryEditDevTeamFromDB(DevTeam team);

        #endregion CrudDB

        //DatabaseMethods
        //[OperationContract]
        //bool UserInDB(int id);
        [OperationContract]
        Employee GetUserByHisCompanyId(string comId);

        [OperationContract]
        Employee GetUserByHisId(int id);

        [OperationContract]
        bool TryAddEmployeeToDB(Employee entity);

        [OperationContract]
        bool TryEditEmployeeInDB(Employee entity);

        [OperationContract]
        bool TryDeleteEmployeeInDB(Employee entity);

        [OperationContract]
        bool TryAddProjectToDB(Project entity);

        [OperationContract]
        bool TryEditProjectInDB(Project entity);

        [OperationContract]
        bool TryDeleteProjectInDB(Project entity);
    }
}