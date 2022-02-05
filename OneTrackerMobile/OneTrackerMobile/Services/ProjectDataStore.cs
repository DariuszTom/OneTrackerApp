using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneTrackerMobile.Services
{
    public class ProjectDataStore : GenericDataStore<Project>
    {
        public override Task<bool> AddItemAsync(Project item)
        {
            return Task.Run(() => base.DbService.TryAddProjectToDB(item));
        }

        public override Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteItemAsync(Project item)
        {
            return await Task.Run(() => base.DbService.TryDeleteProjectInDB(item));
        }

        public override Task<Project> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Project>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.Run(() => DbService.GetAllOpenProjects());
        }

        public override async Task<bool> UpdateItemAsync(Project item)
        {
            return await Task.Run(() => base.DbService.TryEditProjectInDB(item));
        }
    }
}
