using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using PlivanjeMobileApp.Activities;
using PlivanjeMobileApp.Helpers;

namespace PlivanjeMobileApp
{
    [Activity(Label = "Plivanje App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            TextView mainText = FindViewById<TextView>(Resource.Id.mainText);
            TextView secondText = FindViewById<TextView>(Resource.Id.secondText);

            mainText.Text = "Dobrodošli u mobilnu aplikaciju sustava za natjecateljsko plivanje.";
            secondText.Text = "Koristite izbornik kako bi navigirali po sadržaju aplikacije.";
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return HelperMethods.HandleToolbarClick(this, item.ItemId);
        }

        [Java.Interop.Export()]
        public void AddItem(View view)
        {
            return;
        }
    }
}

