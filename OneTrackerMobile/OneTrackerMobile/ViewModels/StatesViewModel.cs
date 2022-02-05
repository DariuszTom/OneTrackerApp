using AsyncAwaitBestPractices.MVVM;
using OneTrackerMobile.Misc.Collection;
using SharedLibrary.Developer;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace OneTrackerMobile.ViewModels
{
    public class StatesViewModel : BaseViewModel
    {
        #region Fields
        private int? _SeletedTeam;
        private StaticTables _StaticTbl;
        private ObservableCollection<DevStats> _RecordList;
        #endregion
        #region Properties
        public ObservableCollection<DevStats> RecordList
        {
            get
            {
                if (_RecordList == null)
                    Task.Run(() => LoadMainViewTable());
                return _RecordList;
            }
            set => base.SetProperty(ref _RecordList, value);
        }
        public int? SeletedTeam
        {
            get => _SeletedTeam;
            set => base.SetProperty(ref _SeletedTeam, value);
        }
        public StaticTables StaticTbl { get => _StaticTbl; set => _StaticTbl = value; }
        #endregion
        #region Constructor
        public StatesViewModel()
        {
            Task.Run(()=> StartActivities());
            RecordList = new ObservableCollection<DevStats>()
                        { new DevStats(2) { FullName = "PlaceHolder", Score = 100 } };
        }
        #endregion
        #region Commands
        private AsyncCommand _LoadListCommand;
        public AsyncCommand LoadListCommand { get => _LoadListCommand = new AsyncCommand(() => LoadMainViewTable()); }
        #endregion
        #region Methods
        private async Task StartActivities()
        {
            StaticTbl = await Task.Run(() => StaticTables.GetInstance);
            base.Title = "Stats";
        }
        public async Task LoadMainViewTable()
        {
            if (SeletedTeam is null)
            {
                await base.ShowSnackBar("Please select team you want stats");
                return;
            }
            Status = "Loading...";

            var res = await StaticTbl.ImportDevStats((int)SeletedTeam);
            RecordList = new ObservableCollection<DevStats>(res);
            Status = RecordList.Count == 0 ? "No records" : "Ready";
        }
        #endregion

    }
}
