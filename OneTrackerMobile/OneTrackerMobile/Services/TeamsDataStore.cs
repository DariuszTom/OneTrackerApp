using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class TeamsDataStore : GenericDataStore<DevTeam>
    {
        public override Task<bool> AddItemAsync(DevTeam item)
        {
            return Task.Run(() => base.DbService.TryAddDevTeamToDB(item));
        }

        public override Task<bool> DeleteItemAsync(int id)
        {
            return Task.Run(() => base.DbService.TryDeleteDevTeamFromDBbyId(id));
        }

        public override Task<bool> DeleteItemAsync(DevTeam item)
        {
            return Task.Run(() => base.DbService.TryDeleteDevTeamFromDB(item));
        }

        public override Task<DevTeam> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<DevTeam>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() => DbService.GetAllDevTeamsRecords());
        }

        public override async Task<bool> UpdateItemAsync(DevTeam item)
        {
            return await Task.Run(() => base.DbService.TryEditDevTeamFromDB(item));
        }
    }
}
