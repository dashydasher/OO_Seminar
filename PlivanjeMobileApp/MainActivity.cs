using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using PlivanjeMobileApp.Activities;

namespace PlivanjeMobileApp
{
    [Activity(Label = "PlivanjeMobileApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button natjecanjaButton = FindViewById<Button>(Resource.Id.mainnatjecanjabut);
            Button kluboviButton = FindViewById<Button>(Resource.Id.mainklubovibut);
            Button plivaciButton = FindViewById<Button>(Resource.Id.mainplivacibut);
            Button rekordiButton = FindViewById<Button>(Resource.Id.mainrekordibut);

            kluboviButton.Click += delegate {
                StartActivity(typeof(KluboviActivity));
            };

            plivaciButton.Click += delegate {
                StartActivity(typeof(PlivaciActivity));
            };

            rekordiButton.Click += delegate {
                StartActivity(typeof(RekordiActivity));
            };
        }


        [Java.Interop.Export()]
        public async void AddItem(View view)
        {
            return;
        }
    }
}

