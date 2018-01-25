using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PlivanjeMobileApp.Models;
using PlivanjeMobileApp.Adapters;
using PlivanjeMobileApp.Helpers;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "Klubovi")]
    public class KluboviActivity : Activity
    {
        ProgressBar progressBar;
        private MobileServiceClient client;
        private IMobileServiceTable<ClubView> clubTable;
        private ClubViewAdapter kluboviAdapter;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListViewLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            client = new MobileServiceClient(applicationURL);

            kluboviAdapter = new ClubViewAdapter(this, Resource.Layout.KluboviLayout);
            var listViewPlace = FindViewById<ListView>(Resource.Id.listViewLayout);
            listViewPlace.Adapter = kluboviAdapter;

            clubTable = client.GetTable<ClubView>();
            var list = await clubTable.ToListAsync();

            kluboviAdapter.Clear();
            foreach (ClubView current in list)
                kluboviAdapter.Add(current);

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            progressBar.Visibility = ViewStates.Gone;
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