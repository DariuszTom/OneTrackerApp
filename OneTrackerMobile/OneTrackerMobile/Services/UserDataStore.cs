using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class UserDataStore : GenericDataStore<Employee>
    {
        public override Task<bool> AddItemAsync(Employee item)
        {
            return Task.Run(() => base.DbService.TryAddEmployeeToDB(item));
        }

        public override Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemAsync(Employee item)
        {
            return Task.Run(() => base.DbService.TryDeleteEmployeeInDB(item));
        }

        public override Task<Employee> GetItemAsync(int id)
        {
            return Task.Run(() => base.DbService.GetUserByHisId(id));
        }

        public override async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() => base.DbService.GetAllEmployeeRecords());
        }

        public override Task<bool> UpdateItemAsync(Employee item)
        {
            return Task.Run(() => base.DbService.TryEditEmployeeInDB(item));
        }
    }
}
