using DbDataLibrary.EFServices;
using DbDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public class GenericDataStore<T> : IDataStore<T> where T : class, IDomainObject
    {
        #region Fields

        private readonly IDbService<T> _dbService;

        #endregion Fields

        #region Contructor

        public GenericDataStore()
        {
            _dbService = new DbService<T>();
        }

        #endregion Contructor

        public virtual async Task<bool> AddItemAsync(T item)
        {
            return await _dbService.AddRecordAsync(item);
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            return await _dbService.DeleteAsync(id);
        }

        public virtual async Task<bool> DeleteItemAsync(T item)
        {
            return await _dbService.DeleteAsync(item);
        }

        public virtual async Task<T> GetItemAsync(int id)
        {
            return await _dbService.GetItemById(id);
        }

        public virtual async Task<List<T>> GetItemsAsync(bool forceRefresh = false)
        {
            var result = new List<T>();
            result = await _dbService.GetAllRecords();
            return result;
        }

        public virtual async Task<bool> UpdateItemAsync(T item)
        {
            return await _dbService.UpdataAsync(item);
        }
    }
}