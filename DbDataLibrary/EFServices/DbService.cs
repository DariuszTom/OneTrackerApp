using DbDataLibrary.Logger;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DbDataLibrary.Logger.LogHelper;

namespace DbDataLibrary.EFServices
{
    public class DbService<T> : IDbService<T> where T : class, IDomainObject
    {
        #region Fields

        private OneTrackerDBContext oneTrackerDBContext;

        #endregion Fields

        #region Contructor

        public DbService()
        { }

        #endregion Contructor

        #region Methods

        public async Task<List<T>> GetAllRecords()
        {
            List<T> result;
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                result = await oneTrackerDBContext.Set<T>().ToListAsync();
            }
            return result;
        }

        public async Task<bool> IsPrimaryKeyInDb(int key)
        {
            bool exist;
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                exist = await oneTrackerDBContext.Set<T>().FindAsync(key) == null;
            }
            return exist;
        }

        #endregion Methods

        #region Crud

        public async Task<T> GetItemById(int Id)
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                return await oneTrackerDBContext.Set<T>().FindAsync(Id); ;
            }
        }

        public async Task<bool> AddRecordAsync(T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    await oneTrackerDBContext.Set<T>().AddAsync(entity);
                    await oneTrackerDBContext.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.InnerException.Message);
                return false;
            }
            return true;
        }

        public bool AddRecord(T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    oneTrackerDBContext.Set<T>().Add(entity);
                    oneTrackerDBContext.SaveChanges();
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.InnerException.Message);
                return false;
            }
            return true;
        }

        public async Task<bool> AddRangeRecordAsync(List<T> entityList)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    await oneTrackerDBContext.Set<T>().AddRangeAsync(entityList);
                    await oneTrackerDBContext.SaveChangesAsync();
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.InnerException.Message);
                return false;
            }
            return true;
        }

        public bool Delete(T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    oneTrackerDBContext.Set<T>().Remove(entity);
                    oneTrackerDBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    T entity = oneTrackerDBContext.Set<T>().FirstOrDefault((e) => e.Id == id);
                    oneTrackerDBContext.Set<T>().Remove(entity);
                    oneTrackerDBContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    T entity = await oneTrackerDBContext.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                    oneTrackerDBContext.Set<T>().Remove(entity);
                    await oneTrackerDBContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    oneTrackerDBContext.Set<T>().Remove(entity);
                    await oneTrackerDBContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        public async Task<T> GetEntityAsync(int id)
        {
            using (oneTrackerDBContext = new OneTrackerDBContext())
            {
                return await oneTrackerDBContext.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            }
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    entity.Id = id;
                    oneTrackerDBContext.Set<T>().Update(entity);
                    await oneTrackerDBContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        public async Task<bool> UpdataAsync(T entity)
        {
            try
            {
                using (oneTrackerDBContext = new OneTrackerDBContext())
                {
                    oneTrackerDBContext.Set<T>().Update(entity);
                    await oneTrackerDBContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception err)
            {
                Log(LogTarget.Database, err.Message);
                return false;
            }
        }

        #endregion Crud
    }
}