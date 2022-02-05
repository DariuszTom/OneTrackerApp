﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/OneTrackerDBService")]
    public partial class CompositeType : object
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmanetForView", Namespace="http://schemas.datacontract.org/2004/07/OneTrackerDBService")]
    public partial class DepartmanetForView : DbDataLibrary.Models.Entities.Department
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DatabaseService.IOneTrackerDbService")]
    public interface IOneTrackerDbService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetData", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<DatabaseService.CompositeType> GetDataUsingDataContractAsync(DatabaseService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllEmployeeRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee>> GetAllEmployeeRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDevTeamsRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam >> GetAllDevTeamsRecordsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecords", ReplyAction="http://tempuri.org/IOneTrackerDbService/GetAllDepartmentsRecordsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseService.DepartmanetForView>> GetAllDepartmentsRecordsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IOneTrackerDbServiceChannel : DatabaseService.IOneTrackerDbService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class OneTrackerDbServiceClient : System.ServiceModel.ClientBase<DatabaseService.IOneTrackerDbService>, DatabaseService.IOneTrackerDbService
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
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public System.Threading.Tasks.Task<DatabaseService.CompositeType> GetDataUsingDataContractAsync(DatabaseService.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.Employee>> GetAllEmployeeRecordsAsync()
        {
            return base.Channel.GetAllEmployeeRecordsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DbDataLibrary.Models.Entities.DevTeam >> GetAllDevTeamsRecordsAsync()
        {
            return base.Channel.GetAllDevTeamsRecordsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DatabaseService.DepartmanetForView>> GetAllDepartmentsRecordsAsync()
        {
            return base.Channel.GetAllDepartmentsRecordsAsync();
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
                return new System.ServiceModel.EndpointAddress("http://localhost:53311/OneTrackerDbService.svc");
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
