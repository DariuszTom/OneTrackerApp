using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(int id);

        Task<bool> DeleteItemAsync(T item);

        Task<T> GetItemAsync(int id);

        Task<List<T>> GetItemsAsync(bool forceRefresh = false);
    }
}