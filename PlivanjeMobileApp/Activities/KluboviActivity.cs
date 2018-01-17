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
        private MobileServiceClient client;
        private IMobileServiceTable<ClubView> clubTable;
        private ClubViewAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListViewLayout);

            CurrentPlatform.Init();
            
            client = new MobileServiceClient(applicationURL);

            clubTable = client.GetTable<ClubView>();

            adapter = new ClubViewAdapter(this, Resource.Layout.KluboviLayout);
            var listViewPlace = FindViewById<ListView>(Resource.Id.listViewLayout);
            listViewPlace.Adapter = adapter;

            try
            {
                var list = await clubTable.ToListAsync();

                adapter.Clear();

                foreach (ClubView current in list)
                    adapter.Add(current);

            }
            catch (Exception e)
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