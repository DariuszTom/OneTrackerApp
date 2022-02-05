using DbDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbDataLibrary.EFServices
{
    public interface IDbService<T> where T : class, IDomainObject
    {
        Task<T> GetItemById(int id);

        Task<bool> AddRangeRecordAsync(List<T> entityList);

        bool AddRecord(T entity);

        Task<bool> AddRecordAsync(T entity);

        bool Delete(int id);

        bool Delete(T entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> DeleteAsync(T entity);

        Task<List<T>> GetAllRecords();

        Task<T> GetEntityAsync(int id);

        Task<bool> IsPrimaryKeyInDb(int key);

        Task<bool> UpdataAsync(T entity);

        Task<bool> UpdateAsync(int id, T entity);
    }
}