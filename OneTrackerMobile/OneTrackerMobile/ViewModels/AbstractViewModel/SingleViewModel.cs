using AsyncAwaitBestPractices.MVVM;
using OneTrackerMobile.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels.AbstractViewModel
{
    public abstract class SingleViewModel<T> : BaseViewModel where T : class
    {
        #region Constructor

        public SingleViewModel()
        {
            _isNew = true;
        }

        protected SingleViewModel(T workItem)
        {
            WorkItem = workItem;
        }

        #endregion Constructor

        #region Fields

        private string _whatToDo;
        private string _MainLabel;
        public IDataStore<T> _dbServiceStore => DependencyService.Get<IDataStore<T>>();

        private T _WorkItem;
        protected internal bool _isNew;

        #endregion Fields

        #region Commands

        private AsyncCommand _AddOrUpdateItem;
        public AsyncCommand AddOrUpdateItem { get => _AddOrUpdateItem = new AsyncCommand(() => AddOrUpdateToDb()); }

        private AsyncCommand _DeleteItemCommand;
        public AsyncCommand DeleteItemCommand { get => _DeleteItemCommand = new AsyncCommand(() => DeleteItemAsync()); }

        #endregion Commands

        #region Properties

        public T WorkItem
        {
            get { return _WorkItem; }
            set
            {
                _WorkItem = value;
                OnPropertyChanged(() => WorkItem);
            }
        }

        public string WhatToDo
        {
            get { return _whatToDo; }
            set => base.SetProperty(ref _whatToDo, value);
        }

        public string MainLabel
        {
            get { return _MainLabel; }
            set => base.SetProperty(ref _MainLabel, value);
        }

        #endregion Properties

        #region PublicMethods

        public virtual async Task AddOrUpdateToDb()
        {
            Status = "Sending";
            bool isSucces = _isNew == true ? await AddItemToDb() : await UpdateItemToDb();
            Status = string.Empty;
            string infoOfOperation = isSucces == true ? "Done, operation was succesfull" :
                                     "Error unable to input to Database";
            await base.ShowMsgBox($"Status:{infoOfOperation}");
        }

        public async Task<bool> AddItemToDb()
        {
            string checkUserInput = CheckUserInput();
            if (!string.IsNullOrEmpty(checkUserInput))
            {
                await ShowErrInfo(checkUserInput, "Error");
                return false;
            }
            return await _dbServiceStore.AddItemAsync(WorkItem);
        }

        public async Task<bool> UpdateItemToDb()
        {
            return await _dbServiceStore.UpdateItemAsync(WorkItem);
        }

        public virtual async Task<bool> DeleteItemAsync()
        {
            if (WorkItem is null) return false;
            return await _dbServiceStore.DeleteItemAsync(WorkItem);
        }

        #endregion PublicMethods

        #region AbstractMethods

        public abstract string CheckUserInput();

        #endregion AbstractMethods
    }
}