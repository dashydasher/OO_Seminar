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

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "Klubovi")]
    public class KluboviActivity : Activity
    {
        ProgressBar progressBar;
        private MobileServiceClient client;
        private IMobileServiceTable<ClubView> clubTable;
        private ClubViewAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListViewLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            CurrentPlatform.Init();

            client = new MobileServiceClient(applicationURL);

            clubTable = client.GetTable<ClubView>();

            adapter = new ClubViewAdapter(this, Resource.Layout.KluboviLayout);
            var listViewPlace = FindViewById<ListView>(Resource.Id.listViewLayout);
            listViewPlace.Adapter = adapter;

            var list = await clubTable.ToListAsync();

            adapter.Clear();
            foreach (ClubView current in list)
                adapter.Add(current);

            progressBar.Visibility = ViewStates.Gone;
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
                case "Početna":
                    StartActivity(typeof(MainActivity));
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