using DbDataLibrary.Models.Entities;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using SharedLibrary.Misc;
using System;

namespace OneTrackerMobile.ViewModels
{
    public class NewDepartmentViewModel : SingleViewModel<Department>
    {
        #region Constructor

        public NewDepartmentViewModel() : base()
        {
            WhatToDo = "New " + nameof(Department);
            base.Title = WhatToDo;
            WorkItem = new Department();
        }

        public NewDepartmentViewModel(Department dep) : base(dep)
        {
            WhatToDo = "Edit " + nameof(Department);
            base.Title = WhatToDo;
        }

        #endregion Constructor

        #region Methods

        public override string CheckUserInput()
        {
            var validator = new InputValidator();
            return validator.CheckInputStrings(new Tuple<string, string>(WorkItem.DepName, nameof(WorkItem.DepName)));
        }

        #endregion Methods
    }
}