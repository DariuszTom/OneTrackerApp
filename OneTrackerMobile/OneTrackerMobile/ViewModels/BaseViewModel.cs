using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace OneTrackerMobile.ViewModels
{
    public class BaseViewModel : BindableObject, INotifyPropertyChanged
    {
        #region Properties and Fields

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set => SetProperty(ref _Status, value);
        }

        #endregion Properties and Fields

        #region PublicMethods

        public async Task ShowMsgBox(string msg, string title = "Info")
        {
            await MaterialDialog.Instance.ConfirmAsync(msg, title);
        }

        public async Task ShowErrInfo(string msg, string title = "Info")
        {
            await MaterialDialog.Instance.AlertAsync(msg, title);
        }

        public async Task ShowSnackBar(string msg)
        {
            await MaterialDialog.Instance.SnackbarAsync(message: msg,
                                            msDuration: MaterialSnackbar.DurationShort);
        }

        #endregion PublicMethods

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            OnPropertyChanged(propertyName);
        }

        private new void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion INotifyPropertyChanged
    }
}