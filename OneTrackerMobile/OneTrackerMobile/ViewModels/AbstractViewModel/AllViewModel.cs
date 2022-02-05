using AsyncAwaitBestPractices.MVVM;
using OneTrackerMobile.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels.AbstractViewModel
{
    public abstract class AllViewModel<T> : BaseViewModel
    {
        #region Constructor

        public AllViewModel()
        {
            // Task.Run(() => LoadMainViewTable());
        }

        #endregion Constructor

        #region Fields

        public IDataStore<T> DbServiceStore => DependencyService.Get<IDataStore<T>>();
        private ObservableCollection<T> _RecordList;
        private T _ItemSelected;

        #endregion Fields

        #region Properties

        public ObservableCollection<T> RecordList
        {
            get
            {
                if (_RecordList == null)
                    Task.Run(() => LoadMainViewTable());
                return _RecordList;
            }
            set => base.SetProperty(ref _RecordList, value);
        }

        public T ItemSelected
        {
            get => _ItemSelected;
            set => base.SetProperty(ref _ItemSelected, value);
        }

        #endregion Properties

        #region Commands

        private AsyncCommand _AddNewItem;
        public AsyncCommand AddNewItem { get => _AddNewItem = new AsyncCommand(() => OnNewItem()); }
        private AsyncCommand _LoadMainList;
        public AsyncCommand LoadMainList { get => _LoadMainList = new AsyncCommand(() => LoadMainViewTable()); }

        #endregion Commands

        #region AbstractMethods

        public abstract Task OnNewItem();

        #endregion AbstractMethods

        #region PublicMethods

        public virtual async Task LoadMainViewTable()
        {
            Status = "Loading...";
            var res = await DbServiceStore.GetItemsAsync();
            RecordList = new ObservableCollection<T>(res);
            Status = RecordList.Count == 0 ? "No records" : "Ready";
        }

        protected internal void RemoveIdItemFormMainList() => RecordList.Remove(ItemSelected);

        #endregion PublicMethods
    }
}