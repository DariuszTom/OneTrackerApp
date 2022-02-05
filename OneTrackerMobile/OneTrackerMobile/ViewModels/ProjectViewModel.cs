using AsyncAwaitBestPractices.MVVM;
using DbDataLibrary.Models.Entities;
using OneTrackerMobile.Misc.Collection;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using SharedLibrary.Misc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OneTrackerMobile.ViewModels
{
    public class ProjectViewModel : SingleViewModel<Project>
    {
        #region Constructor

        public ProjectViewModel() : base()
        {
            WhatToDo = "New " + nameof(Project);
            base.MainLabel = "Add" + nameof(Project);
            WorkItem = new Project();
            StartActivities();
        }

        public ProjectViewModel(Project dep) : base(dep)
        {
            StartActivities();
            WhatToDo = "Edit " + nameof(Project);
            base.MainLabel = "Edit" + nameof(Project);
        }

        #endregion Constructor

        #region Fields

        private StaticTables _StaticTbl;
        private int _PiorityIndex;

        #endregion Fields

        #region Properties

        public StaticTables StaticTbl { get => _StaticTbl; set => _StaticTbl = value; }

        public int PiorityIndex
        {
            get
            {
                return _PiorityIndex;
            }
            set
            {
                WorkItem.Piority = StaticTbl.PriorityStr.ElementAt(value);
                SetProperty(ref _PiorityIndex, value);
            }
        }

        public bool IsNew
        {
            get { return !base._isNew; }
        }

        #endregion Properties

        #region Commands

        private AsyncCommand _ClearIteam;
        public AsyncCommand ClearIteam { get => _ClearIteam = new AsyncCommand(() => ClearItemAsync()); }


        #endregion Commands

        #region Methods

        public override string CheckUserInput()
        {
            var validator = new InputValidator();
            return validator.CheckInputStrings(new Tuple<string, string>(WorkItem.ProjectName, nameof(WorkItem.ProjectName)),
                                                new Tuple<string, string>(WorkItem.RequestingTeam, nameof(WorkItem.RequestingTeam)),
                                                new Tuple<string, string>(WorkItem.ContactPerson, nameof(WorkItem.ContactPerson)),
                                                new Tuple<string, string>(WorkItem.ProjectType, nameof(WorkItem.ProjectType)),
                                                new Tuple<string, string>(WorkItem.ProjectStatus, nameof(WorkItem.ProjectStatus)),
                                                new Tuple<string, string>(WorkItem.Piority, nameof(WorkItem.Piority)));
        }

        private void StartActivities()
        {
            base.Title = WhatToDo;
            StaticTbl = StaticTables.GetInstance;
            if (WorkItem.DueDate is null) WorkItem.DueDate = DateTime.Now;
        }

        private async Task ClearItemAsync()
        {
            WorkItem = new Project();
            await base.ShowSnackBar("Form clear");
        }
        public async override Task<bool> DeleteItemAsync()
        {
            string proName = WorkItem.ProjectName;
            bool isSucces = await base.DeleteItemAsync();
            string infoOfOperation = isSucces ? $"Done, {proName} was remove from database" :
                                     $"Error unable to delete {proName} ";
            await base.ShowMsgBox($"Status:{infoOfOperation}");
            return isSucces;
        }
        #endregion Methods
    }
}