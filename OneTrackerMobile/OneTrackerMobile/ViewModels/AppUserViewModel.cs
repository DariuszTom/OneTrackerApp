using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using OneTrackerDbService;
using OneTrackerMobile.Misc.Settings;
using OneTrackerMobile.Services;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using SharedLibrary.Misc;
using SharedLibrary.User;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class AppUserViewModel : SingleViewModel<Employee>
    {
        #region Constructor

        public AppUserViewModel()
        {
            base.WhatToDo = "Add User";
            SelectionChangedCommand = new
                        Command<Syncfusion.XForms.Buttons.SelectionChangedEventArgs>(SelectionChanged);
            DbService = DependencyService.Get<IOneTrackerDbService>();
            Task.Run(() => TryToGetUser());
            WorkItem = new Employee();
        }

        #endregion Constructor

        #region Fields

        protected internal IOneTrackerDbService DbService { get; set; }
        private List<string> _Positions;
        private ObservableCollection<SfSegmentItem> _ItemCollection = new ObservableCollection<SfSegmentItem>();
        private ObservableCollection<TeamForViewNew> _Teams;

        #endregion Fields

        #region Properties

        public ObservableCollection<TeamForViewNew> Teams
        {
            get => _Teams;

            set => base.SetProperty(ref _Teams, value);
        }

        public List<string> Positions
        {
            get
            {
                if (_Positions is null)
                    Positions = new List<string>()
                    { "A1", "A2", "SA","Off","AVP" };
                return _Positions;
            }

            set => _Positions = value;
        }

        public ObservableCollection<SfSegmentItem> ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; }
        }

        #endregion Properties

        #region Commands

        public Command SelectionChangedCommand
        {
            get;
            set;
        }

        #endregion Commands

        #region Methods

        private async Task TryToGetUser()
        {
            await LoadTeam();
            Func<string, Task<Employee>> getEmp =
                                (a) => Task.Run(() => DbService.GetUserByHisCompanyId(a));

            string compId = Settings.UserCompanyId;
            if (!string.IsNullOrEmpty(compId))
            {
                var user = await getEmp(compId);
                switch (user is null)
                {
                    case false:
                        var userInfo = UserInfo.GetInstance;
                        userInfo.AppUser = user;
                        WorkItem = user;
                        _isNew = false;
                        Status = "User find in Db"; base.WhatToDo = "Edit User"; break;
                    default:
                        Status = "Please provida your personal details"; break;
                }
            }
        }

        public override string CheckUserInput()
        {
            var validator = new InputValidator();
            return validator.CheckInputStrings(new Tuple<string, string>(WorkItem.IdEmployee, nameof(WorkItem.IdEmployee)),
                                                new Tuple<string, string>(WorkItem.EmpName, nameof(WorkItem.EmpName)),
                                                new Tuple<string, string>(WorkItem.EmpSurname, nameof(WorkItem.EmpSurname)),
                                                new Tuple<string, string>(WorkItem.Mail, nameof(WorkItem.Mail)),
                                                new Tuple<string, string>(WorkItem.IdEmployee, nameof(WorkItem.IdEmployee)),
                                                new Tuple<string, string>(WorkItem.Team.ToString(), nameof(WorkItem.Team)));
        }

        private void SelectionChanged(Syncfusion.XForms.Buttons.SelectionChangedEventArgs obj) =>
                                        WorkItem.Position = Positions[obj.Index];

        private async Task LoadTeam()
        {
            var depService = DependencyService.Get<IDataStore<TeamForViewNew>>();
            Teams = new ObservableCollection<TeamForViewNew>(await depService.GetItemsAsync());
        }

        #endregion Methods

        #region OverridesMethods

        public override async Task AddOrUpdateToDb()
        {
            var dep = from team in Teams
                      where team.Id == WorkItem.Team
                      select team.DepartamentNavigation.Id;

            WorkItem.Departament = dep.FirstOrDefault();
            if (!string.IsNullOrEmpty(WorkItem.IdEmployee)) Settings.UserCompanyId = WorkItem.IdEmployee;
            await base.AddOrUpdateToDb();
        }

        #endregion OverridesMethods
    }
}