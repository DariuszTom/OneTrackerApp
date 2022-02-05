using DbDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class TeamsViewDataStore : GenericDataStore<TeamForViewNew>
    {
        public override Task<bool> AddItemAsync(TeamForViewNew item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemAsync(TeamForViewNew item)
        {
            throw new NotImplementedException();
        }

        public override Task<TeamForViewNew> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<TeamForViewNew>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() => DbService.GetAllTeamForViewRecords());
        }

        public override Task<bool> UpdateItemAsync(TeamForViewNew item)
        {
            throw new NotImplementedException();
        }
    }
}
