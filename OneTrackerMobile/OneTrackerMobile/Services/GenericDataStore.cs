using OneTrackerDbService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.Services
{
    public abstract class GenericDataStore<T> : IDataStore<T>
    {
        #region Fields
       protected internal IOneTrackerDbService DbService { get; set; }
        #endregion
        #region Constructor
        public GenericDataStore()
        {
           DbService = DependencyService.Get<IOneTrackerDbService>();
        }
        #endregion
        #region AbstractMethods
        public abstract Task<bool> DeleteItemAsync(int id);
        public abstract Task<bool> DeleteItemAsync(T item);
        public abstract Task<T> GetItemAsync(int id);

        public abstract Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        public abstract Task<bool> UpdateItemAsync(T item);
        #endregion
        #region PublicMethods
        public abstract Task<bool> AddItemAsync(T item);
        
        #endregion


    }
}
