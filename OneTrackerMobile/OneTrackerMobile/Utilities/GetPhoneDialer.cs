using System;
using Xamarin.Essentials;

namespace OneTrackerMobile.Services
{
    public class GetPhoneDialer
    {
        public (string msg, bool isSucces) PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
                return ("Succes", true);
            }
            catch (ArgumentNullException anEx)
            {
                return (anEx.Message, false);
            }
            catch (FeatureNotSupportedException ex)
            {
                return (ex.Message, false);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
    }
}
