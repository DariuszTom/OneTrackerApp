using DbDataLibrary.Models.Entities;
using OneTrackerMobile.Services;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using SharedLibrary.Misc;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneTrackerMobile.ViewModels
{
    public class NewTeamViewModel : SingleViewModel<DevTeam>
    {
        #region Constructor

        public NewTeamViewModel() : base()
        {
            WhatToDo = "New " + nameof(DevTeam);
            base.MainLabel = "Add" + nameof(DevTeam);
            base.Title = WhatToDo;
            WorkItem = new DevTeam();
        }

        public NewTeamViewModel(DevTeam dep) : base(dep)
        {
            WhatToDo = "Edit " + nameof(DevTeam);
            base.MainLabel = "Edit" + nameof(DevTeam);
            base.Title = WhatToDo;
        }

        #endregion Constructor

        #region FieldsAndProperties

        private ObservableCollection<Department> _DepList;

        public ObservableCollection<Department> DepList
        {
            get
            {
                if (_DepList is null)
                {
                    Task.Run(() => LoadDepartments());
                }
                return _DepList;
            }
            set { base.SetProperty(ref _DepList, value); }
        }

        #endregion FieldsAndProperties

        #region Methods

        public override string CheckUserInput()
        {
            var validator = new InputValidator();
            return validator.CheckInputStrings(new Tuple<string, string>(WorkItem.TeamName, nameof(WorkItem.TeamName)),
                                                new Tuple<string, string>(WorkItem.Departament.ToString(), nameof(WorkItem.Departament)),
                                                new Tuple<string, string>(WorkItem.Mail, nameof(WorkItem.Mail)),
                                                new Tuple<string, string>(WorkItem.Manager, nameof(WorkItem.Manager)));
        }

        private async Task LoadDepartments()
        {
            var depService = DependencyService.Get<IDataStore<Department>>();
            DepList = new ObservableCollection<Department>(await depService.GetItemsAsync());
        }

        #endregion Methods
    }
}