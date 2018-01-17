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
    [Activity(Label = "KluboviActivity")]
    public class KluboviActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<Club> clubTable;
        private OneStringAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Klubovi);

            CurrentPlatform.Init();
            
            client = new MobileServiceClient(applicationURL);

            clubTable = client.GetTable<Club>();

            adapter = new OneStringAdapter(this, Resource.Layout.MediumTextLayout);
            var listViewPlace = FindViewById<ListView>(Resource.Id.Klubovi);
            listViewPlace.Adapter = adapter;

            try
            {
                var list = await clubTable.ToListAsync();

                adapter.Clear();

                foreach (Club current in list)
                    adapter.Add(current.Name);

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