using DbDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class DevelopersViewDataStore : GenericDataStore<DeveloperForView>
    {
        public override Task<bool> AddItemAsync(DeveloperForView item)
        {
            throw new NotImplementedException();
        }
        public override Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemAsync(DeveloperForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<DeveloperForView> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<DeveloperForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() => base.DbService.GetAllDevelopersRecords());
        }

        public override Task<bool> UpdateItemAsync(DeveloperForView item)
        {
            throw new NotImplementedException();
        }
    }
}
