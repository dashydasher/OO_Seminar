using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using PlivanjeMobileApp.Activities;

namespace PlivanjeMobileApp
{
    [Activity(Label = "Plivanje App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            Button natjecanjaButton = FindViewById<Button>(Resource.Id.mainnatjecanjabut);
            Button kluboviButton = FindViewById<Button>(Resource.Id.mainklubovibut);
            Button plivaciButton = FindViewById<Button>(Resource.Id.mainplivacibut);
            Button rekordiButton = FindViewById<Button>(Resource.Id.mainrekordibut);

            natjecanjaButton.Click += delegate {
                StartActivity(typeof(NatjecanjaActivity));
            };

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
                case "Natjecanja":
                    StartActivity(typeof(NatjecanjaActivity));
                    break;
                case "Klubovi":
                    StartActivity(typeof(KluboviActivity));
                    break;
                case "Plivači":
                    StartActivity(typeof(PlivaciActivity));
                    break;
                case "Rekordi":
                    StartActivity(typeof(RekordiActivity));
                    break;
                case "Search":
                    Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        [Java.Interop.Export()]
        public void AddItem(View view)
        {
            return;
        }
    }
}

