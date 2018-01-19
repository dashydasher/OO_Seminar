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
using Microsoft.WindowsAzure.MobileServices;
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "RekordiActivity")]
    public class RekordiActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Rekordi);

            this.Title = "Rekordi";

            Button muskiButton = FindViewById<Button>(Resource.Id.rekordimbut);
            Button zenskiButton = FindViewById<Button>(Resource.Id.rekordizbut);

            var activity = new Intent(this, typeof(PrikazRekordiActivity));

            muskiButton.Click += delegate {
                activity.PutExtra("gender", "m");
                StartActivity(activity);
            };
            zenskiButton.Click += delegate {
                activity.PutExtra("gender", "ž");
                StartActivity(activity);
            };
        }
    }
}