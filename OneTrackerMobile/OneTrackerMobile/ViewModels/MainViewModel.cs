using System;

namespace OneTrackerMobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Constructor

        private static readonly Lazy<MainViewModel> lazy =
        new Lazy<MainViewModel>(() => new MainViewModel());

        public static MainViewModel GetInstance
        { get { return lazy.Value; } }

        private MainViewModel()
        {
            this.Title = "MainPage";
        }

        #endregion Constructor
    }
}