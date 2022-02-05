using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SharedLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

[assembly:Xamarin.Forms.Dependency(typeof(OneTrackerMobile.Droid.PlatformCode.NetworkManager))]
namespace OneTrackerMobile.Droid.PlatformCode
{
    public class NetworkManager : INetworkManager
    {
        #region Fields
        #endregion
        public NetworkManager()
        {

        }
        bool INetworkManager.IsConnectedToNet()
        {
            //            var cSvc = (ConnectivityManager)ctx.GetSystemService(Context.ConnectivityService);
            //#pragma warning disable CS0618 // Type or member is obsolete
            //            return cSvc.ActiveNetworkInfo.IsConnected;
            //#pragma warning restore CS0618 // Type or member is obsolete

            var current = Connectivity.NetworkAccess;
            return current== NetworkAccess.Internet;
        }

        bool INetworkManager.IsServiceConnected()
        {
            throw new NotImplementedException();
        }
    }
}