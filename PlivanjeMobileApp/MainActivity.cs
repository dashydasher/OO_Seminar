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

namespace PlivanjeMobileApp
{
    [Activity(Label = "PlivanjeMobileApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<Place> placeTable;
        private PlaceAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListViewLayout);

            CurrentPlatform.Init();

            client = new MobileServiceClient(applicationURL);

            placeTable = client.GetTable<Place>();

            adapter = new PlaceAdapter(this, Resource.Layout.MediumTextLayout);
            var listViewPlace = FindViewById<ListView>(Resource.Id.listViewLayout);
            listViewPlace.Adapter = adapter;

            try
            {
                var list = await placeTable.ToListAsync();

                adapter.Clear();

                foreach (Place current in list)
                    adapter.Add(current);

            } catch(Exception e)
            {
            }
        }
        

        [Java.Interop.Export()]
        public async void AddItem(View view)
        {
            return;
        }
    }
}

