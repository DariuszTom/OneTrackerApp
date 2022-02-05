using DbDataLibrary.Models.Entities;
using OneTrackerMobile.ViewModels.AbstractViewModel;
using System;

namespace OneTrackerMobile.ViewModels
{
    public class ProjectDetailsViewModel : SingleViewModel<Project>
    {
        #region Contructor

        public ProjectDetailsViewModel(Project project) : base(project)
        {
            base.Title = $"Id: {WorkItem.Id}";
        }

        public ProjectDetailsViewModel()
        { }

        #endregion Contructor

        #region Methods

        public override string CheckUserInput()
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}