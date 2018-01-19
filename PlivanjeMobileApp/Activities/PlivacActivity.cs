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
using PlivanjeMobileApp.Adapters;
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "PlivacActivity")]
    public class PlivacActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private SwimmerAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.Plivac);

            // Create your application here

            string idPlivaca = Intent.GetStringExtra("id") ?? "Data not available";
            string gender = Intent.GetStringExtra("gender") ?? "Data not available";
            string dateOfBirth = Intent.GetStringExtra("dateOfBirth") ?? "Data not available";
            string label = Intent.GetStringExtra("label") ?? "Data not available";
            this.Title = label.Trim() + ", " + gender;

            TextView spol = FindViewById<TextView>(Resource.Id.podaci);
            spol.Text = "Datum rođenja: " + dateOfBirth.Trim();

            swimmersTable = client.GetTable<SwimmersView>();

            List<SwimmersView> list = await swimmersTable.Where(e => e.Id == idPlivaca).ToListAsync();

            adapter = new SwimmerAdapter(this, Resource.Layout.SezonaPlivaca);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.sezone);
            listViewClubSwimmers.Adapter = adapter;

            adapter.Clear();
            foreach (SwimmersView current in list)
                adapter.Add(current);
        }
    }
}