using DbDataLibrary.GroupCollection;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using MvvmBlazor.ViewModel;
using OneTrackerWeb.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneTrackerWeb.ViewModel
{
    public abstract class BaseViewModel<T> : ViewModelBase
    {
        #region Contructor

        public BaseViewModel()
        {
            _isNew = true;
            ButtonTxt = "Add";
        }

        protected BaseViewModel(T workItem)
        {
            WorkItem = workItem;
            ButtonTxt = "Edit";
        }

        #endregion Contructor

        #region Fields

        public IDataStore<T> DbServiceStore;
        private T _WorkItem;
        protected bool _isNew;
        protected string _title;
        private DictionaryTables _DicOfTables;
        private string _btnTxt;

        #endregion Fields

        #region Properties

        [Inject]
        public IMatToaster Toaster { get; set; }

        public T WorkItem
        {
            get { return _WorkItem; }
            set => base.Set(ref _WorkItem, value);
        }

        public string Title
        {
            get { return _title; }
            set => base.Set(ref _title, value);
        }

        public string ButtonTxt
        {
            get => _btnTxt;
            set => base.Set(ref _btnTxt, value);
        }

        public DictionaryTables DicOfTables
        {
            get
            {
                if (_DicOfTables is null) _DicOfTables = DictionaryTables.Instance;
                return _DicOfTables;
            }
        }

        public bool IsNew
        {
            get { return _isNew; }
            set => base.Set(ref _isNew, value);
        }

        #endregion Properties



        #region Methods

        public virtual async Task<List<T>> LoadMainViewTable()
        {
            var res = await DbServiceStore.GetItemsAsync();
            Toaster.Add($"Refresh main List", MatToastType.Info);
            return new List<T>(res);
        }

        public virtual void ClearAfterEdit()
        {
            IsNew = true;
            ButtonTxt = "Add";
        }

        #region Crud

        public virtual async Task<bool> AddItemToDb()
        {
            if (WorkItem is not null)
            {
                return await DbServiceStore.AddItemAsync(WorkItem);
            }
            return false;
        }

        public virtual async Task<bool> AddItemToDb(T item)
        {
            return await DbServiceStore.AddItemAsync(item);
        }

        public virtual async Task<bool> DeletetemToDb()
        {
            if (WorkItem is not null)
            {
                return await DbServiceStore.DeleteItemAsync(WorkItem);
            }
            return false;
        }

        public virtual async Task<bool> DeletetemToDb(T item)
        {
            return await DbServiceStore.DeleteItemAsync(item);
        }

        public virtual async Task<bool> UpdatetemToDb()
        {
            if (WorkItem is not null)
            {
                return await DbServiceStore.UpdateItemAsync(WorkItem);
            }
            return false;
        }

        public virtual async Task<bool> UpdatetemToDb(T item)
        {
            return await DbServiceStore.UpdateItemAsync(item);
        }

        #endregion Crud

        #endregion Methods
    }
}