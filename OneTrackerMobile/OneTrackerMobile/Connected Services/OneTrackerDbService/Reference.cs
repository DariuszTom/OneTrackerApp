﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OneTrackerDbService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OneTrackerDbService.IOneTrackerDbService")]
    public interface IOneTrackerDbService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetData", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetData", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/DataBaseExists", ReplyAction="http://tempuri.org/IOneTrackerDbService/DataBaseExistsResponse")]
        bool DataBaseExists();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/DataBaseExists", ReplyAction="http://tempuri.org/IOneTrackerDbService/DataBaseExistsResponse")]
        System.Threading.Tasks.Task<bool> DataBaseExistsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee> GetAllEmployeeRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee>> GetAllEmployeeRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam> GetAllDevTeamsRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam>> GetAllDevTeamsRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllTeamForViewRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllTeamForViewRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.TeamForViewNew> GetAllTeamForViewRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllTeamForViewRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllTeamForViewRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.TeamForViewNew>> GetAllTeamForViewRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.Department> GetAllDepartmentsRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Department>> GetAllDepartmentsRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectStatusRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectStatusRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectStatus> GetAllProjectStatusRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectStatusRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectStatusRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectStatus>> GetAllProjectStatusRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectTypesRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectTypesRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectType> GetAllProjectTypesRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectTypesRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectTypesRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectType>> GetAllProjectTypesRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectPriorityRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectPriorityRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectPriority> GetAllProjectPriorityRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllProjectPriorityRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllProjectPriorityRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectPriority>> GetAllProjectPriorityRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDevelopersRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDevelopersRecordsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.DeveloperForView> GetAllDevelopersRecords();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDevelopersRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDevelopersRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.DeveloperForView>> GetAllDevelopersRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllOpenProjects", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllOpenProjectsResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.Entities.Project> GetAllOpenProjects();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllOpenProjects", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllOpenProjectsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Project>> GetAllOpenProjectsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetOpenProjectsWithNavigation", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetOpenProjectsWithNavigationResponse")]
        System.Collections.Generic.List<DbDataLibrary.Models.ProjectForView> GetOpenProjectsWithNavigation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetOpenProjectsWithNavigation", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetOpenProjectsWithNavigationResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.ProjectForView>> GetOpenProjectsWithNavigationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetDevStats", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDevStatsResponse")]
        System.Collections.Generic.List<SharedLibrary.Developer.DevStats> GetDevStats(int teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetDevStats", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDevStatsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<SharedLibrary.Developer.DevStats>> GetDevStatsAsync(int teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddDepartmentToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddDepartmentToDBResponse")]
        bool TryAddDepartmentToDB(DbDataLibrary.Models.Entities.Department entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddDepartmentToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddDepartmentToDBResponse")]
        System.Threading.Tasks.Task<bool> TryAddDepartmentToDBAsync(DbDataLibrary.Models.Entities.Department entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddDevTeamToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddDevTeamToDBResponse")]
        bool TryAddDevTeamToDB(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddDevTeamToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddDevTeamToDBResponse")]
        System.Threading.Tasks.Task<bool> TryAddDevTeamToDBAsync(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBbyId", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBbyIdResponse")]
        bool TryDeleteDevTeamFromDBbyId(int teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBbyId", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBbyIdResponse")]
        System.Threading.Tasks.Task<bool> TryDeleteDevTeamFromDBbyIdAsync(int teamId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBResponse")]
        bool TryDeleteDevTeamFromDB(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteDevTeamFromDBResponse")]
        System.Threading.Tasks.Task<bool> TryDeleteDevTeamFromDBAsync(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditDevTeamFromDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditDevTeamFromDBResponse")]
        bool TryEditDevTeamFromDB(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditDevTeamFromDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditDevTeamFromDBResponse")]
        System.Threading.Tasks.Task<bool> TryEditDevTeamFromDBAsync(DbDataLibrary.Models.Entities.DevTeam team);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetUserByHisCompanyId", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetUserByHisCompanyIdResponse")]
        DbDataLibrary.Models.Entities.Employee GetUserByHisCompanyId(string comId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetUserByHisCompanyId", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetUserByHisCompanyIdResponse")]
        System.Threading.Tasks.Task<DbDataLibrary.Models.Entities.Employee> GetUserByHisCompanyIdAsync(string comId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetUserByHisId", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetUserByHisIdResponse")]
        DbDataLibrary.Models.Entities.Employee GetUserByHisId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetUserByHisId", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetUserByHisIdResponse")]
        System.Threading.Tasks.Task<DbDataLibrary.Models.Entities.Employee> GetUserByHisIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddEmployeeToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddEmployeeToDBResponse")]
        bool TryAddEmployeeToDB(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddEmployeeToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddEmployeeToDBResponse")]
        System.Threading.Tasks.Task<bool> TryAddEmployeeToDBAsync(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditEmployeeInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditEmployeeInDBResponse")]
        bool TryEditEmployeeInDB(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditEmployeeInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditEmployeeInDBResponse")]
        System.Threading.Tasks.Task<bool> TryEditEmployeeInDBAsync(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteEmployeeInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteEmployeeInDBResponse")]
        bool TryDeleteEmployeeInDB(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteEmployeeInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteEmployeeInDBResponse")]
        System.Threading.Tasks.Task<bool> TryDeleteEmployeeInDBAsync(DbDataLibrary.Models.Entities.Employee entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddProjectToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddProjectToDBResponse")]
        bool TryAddProjectToDB(DbDataLibrary.Models.Entities.Project entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryAddProjectToDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryAddProjectToDBResponse")]
        System.Threading.Tasks.Task<bool> TryAddProjectToDBAsync(DbDataLibrary.Models.Entities.Project entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditProjectInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditProjectInDBResponse")]
        bool TryEditProjectInDB(DbDataLibrary.Models.Entities.Project entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryEditProjectInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryEditProjectInDBResponse")]
        System.Threading.Tasks.Task<bool> TryEditProjectInDBAsync(DbDataLibrary.Models.Entities.Project entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteProjectInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteProjectInDBResponse")]
        bool TryDeleteProjectInDB(DbDataLibrary.Models.Entities.Project entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/TryDeleteProjectInDB", ReplyAction="http://tempuri.org/IOneTrackerDbService/TryDeleteProjectInDBResponse")]
        System.Threading.Tasks.Task<bool> TryDeleteProjectInDBAsync(DbDataLibrary.Models.Entities.Project entity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IOneTrackerDbServiceChannel : OneTrackerDbService.IOneTrackerDbService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class OneTrackerDbServiceClient : System.ServiceModel.ClientBase<OneTrackerDbService.IOneTrackerDbService>, OneTrackerDbService.IOneTrackerDbService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public OneTrackerDbServiceClient() : 
                base(OneTrackerDbServiceClient.GetDefaultBinding(), OneTrackerDbServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IOneTrackerDbService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OneTrackerDbServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(OneTrackerDbServiceClient.GetBindingForEndpoint(endpointConfiguration), OneTrackerDbServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OneTrackerDbServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(OneTrackerDbServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OneTrackerDbServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(OneTrackerDbServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OneTrackerDbServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string GetData(int value)
        {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public bool DataBaseExists()
        {
            return base.Channel.DataBaseExists();
        }
        
        public System.Threading.Tasks.Task<bool> DataBaseExistsAsync()
        {
            return base.Channel.DataBaseExistsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee> GetAllEmployeeRecords()
        {
            return base.Channel.GetAllEmployeeRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee>> GetAllEmployeeRecordsAsync()
        {
            return base.Channel.GetAllEmployeeRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam> GetAllDevTeamsRecords()
        {
            return base.Channel.GetAllDevTeamsRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam>> GetAllDevTeamsRecordsAsync()
        {
            return base.Channel.GetAllDevTeamsRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.TeamForViewNew> GetAllTeamForViewRecords()
        {
            return base.Channel.GetAllTeamForViewRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.TeamForViewNew>> GetAllTeamForViewRecordsAsync()
        {
            return base.Channel.GetAllTeamForViewRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.Department> GetAllDepartmentsRecords()
        {
            return base.Channel.GetAllDepartmentsRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Department>> GetAllDepartmentsRecordsAsync()
        {
            return base.Channel.GetAllDepartmentsRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectStatus> GetAllProjectStatusRecords()
        {
            return base.Channel.GetAllProjectStatusRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectStatus>> GetAllProjectStatusRecordsAsync()
        {
            return base.Channel.GetAllProjectStatusRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectType> GetAllProjectTypesRecords()
        {
            return base.Channel.GetAllProjectTypesRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectType>> GetAllProjectTypesRecordsAsync()
        {
            return base.Channel.GetAllProjectTypesRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectPriority> GetAllProjectPriorityRecords()
        {
            return base.Channel.GetAllProjectPriorityRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.ProjectPriority>> GetAllProjectPriorityRecordsAsync()
        {
            return base.Channel.GetAllProjectPriorityRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.DeveloperForView> GetAllDevelopersRecords()
        {
            return base.Channel.GetAllDevelopersRecords();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.DeveloperForView>> GetAllDevelopersRecordsAsync()
        {
            return base.Channel.GetAllDevelopersRecordsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.Entities.Project> GetAllOpenProjects()
        {
            return base.Channel.GetAllOpenProjects();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Project>> GetAllOpenProjectsAsync()
        {
            return base.Channel.GetAllOpenProjectsAsync();
        }
        
        public System.Collections.Generic.List<DbDataLibrary.Models.ProjectForView> GetOpenProjectsWithNavigation()
        {
            return base.Channel.GetOpenProjectsWithNavigation();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.ProjectForView>> GetOpenProjectsWithNavigationAsync()
        {
            return base.Channel.GetOpenProjectsWithNavigationAsync();
        }
        
        public System.Collections.Generic.List<SharedLibrary.Developer.DevStats> GetDevStats(int teamId)
        {
            return base.Channel.GetDevStats(teamId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<SharedLibrary.Developer.DevStats>> GetDevStatsAsync(int teamId)
        {
            return base.Channel.GetDevStatsAsync(teamId);
        }
        
        public bool TryAddDepartmentToDB(DbDataLibrary.Models.Entities.Department entity)
        {
            return base.Channel.TryAddDepartmentToDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryAddDepartmentToDBAsync(DbDataLibrary.Models.Entities.Department entity)
        {
            return base.Channel.TryAddDepartmentToDBAsync(entity);
        }
        
        public bool TryAddDevTeamToDB(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryAddDevTeamToDB(team);
        }
        
        public System.Threading.Tasks.Task<bool> TryAddDevTeamToDBAsync(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryAddDevTeamToDBAsync(team);
        }
        
        public bool TryDeleteDevTeamFromDBbyId(int teamId)
        {
            return base.Channel.TryDeleteDevTeamFromDBbyId(teamId);
        }
        
        public System.Threading.Tasks.Task<bool> TryDeleteDevTeamFromDBbyIdAsync(int teamId)
        {
            return base.Channel.TryDeleteDevTeamFromDBbyIdAsync(teamId);
        }
        
        public bool TryDeleteDevTeamFromDB(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryDeleteDevTeamFromDB(team);
        }
        
        public System.Threading.Tasks.Task<bool> TryDeleteDevTeamFromDBAsync(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryDeleteDevTeamFromDBAsync(team);
        }
        
        public bool TryEditDevTeamFromDB(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryEditDevTeamFromDB(team);
        }
        
        public System.Threading.Tasks.Task<bool> TryEditDevTeamFromDBAsync(DbDataLibrary.Models.Entities.DevTeam team)
        {
            return base.Channel.TryEditDevTeamFromDBAsync(team);
        }
        
        public DbDataLibrary.Models.Entities.Employee GetUserByHisCompanyId(string comId)
        {
            return base.Channel.GetUserByHisCompanyId(comId);
        }
        
        public System.Threading.Tasks.Task<DbDataLibrary.Models.Entities.Employee> GetUserByHisCompanyIdAsync(string comId)
        {
            return base.Channel.GetUserByHisCompanyIdAsync(comId);
        }
        
        public DbDataLibrary.Models.Entities.Employee GetUserByHisId(int id)
        {
            return base.Channel.GetUserByHisId(id);
        }
        
        public System.Threading.Tasks.Task<DbDataLibrary.Models.Entities.Employee> GetUserByHisIdAsync(int id)
        {
            return base.Channel.GetUserByHisIdAsync(id);
        }
        
        public bool TryAddEmployeeToDB(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryAddEmployeeToDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryAddEmployeeToDBAsync(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryAddEmployeeToDBAsync(entity);
        }
        
        public bool TryEditEmployeeInDB(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryEditEmployeeInDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryEditEmployeeInDBAsync(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryEditEmployeeInDBAsync(entity);
        }
        
        public bool TryDeleteEmployeeInDB(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryDeleteEmployeeInDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryDeleteEmployeeInDBAsync(DbDataLibrary.Models.Entities.Employee entity)
        {
            return base.Channel.TryDeleteEmployeeInDBAsync(entity);
        }
        
        public bool TryAddProjectToDB(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryAddProjectToDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryAddProjectToDBAsync(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryAddProjectToDBAsync(entity);
        }
        
        public bool TryEditProjectInDB(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryEditProjectInDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryEditProjectInDBAsync(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryEditProjectInDBAsync(entity);
        }
        
        public bool TryDeleteProjectInDB(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryDeleteProjectInDB(entity);
        }
        
        public System.Threading.Tasks.Task<bool> TryDeleteProjectInDBAsync(DbDataLibrary.Models.Entities.Project entity)
        {
            return base.Channel.TryDeleteProjectInDBAsync(entity);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOneTrackerDbService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOneTrackerDbService))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.0.220:53311/OneTrackerDbService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return OneTrackerDbServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IOneTrackerDbService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return OneTrackerDbServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IOneTrackerDbService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IOneTrackerDbService,
        }
    }
}
