using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlivanjeMobileApp.Activities;

namespace PlivanjeMobileApp.Helpers
{
    class HelperMethods
    {
        public static bool HandleToolbarClick(Activity activity, int itemId)
        {
            switch (itemId)
            {
                case Resource.Id.menu_natjecanja:
                    activity.StartActivity(typeof(NatjecanjaActivity));
                    break;
                case Resource.Id.menu_klubovi:
                    activity.StartActivity(typeof(KluboviActivity));
                    break;
                case Resource.Id.menu_plivaci:
                    activity.StartActivity(typeof(PlivaciActivity));
                    break;
                case Resource.Id.menu_rekordi:
                    activity.StartActivity(typeof(RekordiActivity));
                    break;
                case Resource.Id.menu_index:
                    activity.StartActivity(typeof(MainActivity));
                    break;
            }
            return true;
        }
    }
}