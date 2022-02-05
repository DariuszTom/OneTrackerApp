using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class DepartamentsDataStore : GenericDataStore<Department>
    {
        public override Task<bool> AddItemAsync(Department item)
        {
            return Task.Run(()=> base.DbService.TryAddDepartmentToDB(item));
        }

        public override Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemAsync(Department item)
        {
            throw new NotImplementedException();
        }

        public override Task<Department> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Department>> GetItemsAsync(bool forceRefresh = false)
        {
           return await Task.Run(() => DbService.GetAllDepartmentsRecords()) ;
        }

        public override Task<bool> UpdateItemAsync(Department item)
        {
            throw new NotImplementedException();
        }
    }
}
