using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.Models;
using OneTrackerMobile.Services;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace OneTrackerMobile.ViewModels
{
    public class DevelopersViewModel : AllViewModel<DeveloperForView>
    {
        #region Construct

        public DevelopersViewModel() : base()
        {
            base.Title = "Developers";
            Task.Run(() => base.LoadMainViewTable());
            SearchTxtChangeCommand = new AsyncCommand(SearchInCollection);
        }

        #region Fields

        private string _SearchTxt;
        private ObservableCollection<DeveloperForView> _DevList;

        #endregion Fields

        #region Properties

        public string SearchTxt
        {
            get { return _SearchTxt; }
            set => base.SetProperty(ref _SearchTxt, value);
        }

        public ObservableCollection<DeveloperForView> DevList
        {
            get
            {
                if (_DevList == null)
                    Task.Run(() => LoadMainViewTable());
                return _DevList;
            }
            set => base.SetProperty(ref _DevList, value);
        }

        #endregion Properties

        #endregion Construct

        #region Commands

        private AsyncCommand<string> _MakeCallCommand;
        public AsyncCommand<string> MakeCallComman { get => _MakeCallCommand = new AsyncCommand<string>((obj) => MakeCall(obj)); }

        public AsyncCommand SearchTxtChangeCommand
        {
            get;
            set;
        }

        #endregion Commands

        #region Methods

        public override async Task LoadMainViewTable()
        {
            await base.LoadMainViewTable();
            DevList = RecordList;
        }

        private async Task SearchInCollection()
        {
            if (string.IsNullOrEmpty(SearchTxt))
            {
                DevList = RecordList;
                return;
            }
            var searchRes = RecordList
                .Where(d => string.Concat(d.EmpName, d.EmpName).Contains(_SearchTxt) ||
                d.IdEmployee.Contains(_SearchTxt));
            DevList = new ObservableCollection<DeveloperForView>(searchRes);
        }

        private async Task MakeCall(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
            {
                await ShowSnackBar("Number no provided");
                return;
            }
            var phoneDialer = new GetPhoneDialer();
            var res = phoneDialer.PlacePhoneCall(phoneNum);
            if (res.isSucces == false) await base.ShowSnackBar(res.msg);
        }

        public override Task OnNewItem()
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}