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
    [Activity(Label = "Klub - Plivači")]
    public class ClubDetailsActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<ClubSwimmerView> swimmersTable;
        private ClubSwimmersAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ClubDetailsLayout);
            string id = Intent.GetStringExtra("id") ?? "Data not available";
            string name = Intent.GetStringExtra("name") ?? "Data not available";
            string place = Intent.GetStringExtra("place") ?? "Data not available";
            string postalcode = Intent.GetStringExtra("postalcode") ?? "Data not available";

            var textView = FindViewById<TextView>(Resource.Id.nazivKluba);
            textView.Text = name;
            var textView2 = FindViewById<TextView>(Resource.Id.mjesto);
            textView2.Text = postalcode + "  " + place;

            CurrentPlatform.Init();

            client = new MobileServiceClient(applicationURL);

            swimmersTable = client.GetTable<ClubSwimmerView>();

            adapter = new ClubSwimmersAdapter(this, Resource.Layout.ClubSwimmerLayout);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.plivaci);
            listViewClubSwimmers.Adapter = adapter;

            try
            {
                var list = await swimmersTable.Where(e => e.IdClub == id).ToListAsync();

                adapter.Clear();

                foreach (ClubSwimmerView current in list)
                    adapter.Add(current);

            }
            catch (Exception e)
            {
            }
        }
    }
}