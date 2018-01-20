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
    [Activity(Label = "UtrkaDetaljiActivity")]
    public class UtrkaDetaljiActivity : Activity
    {
        private IMobileServiceTable<SwimmerRaceView> swimmersTable;
        private MobileServiceClient client;
        private UtrkaDetaljiAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.UtrkaDetaljiLayout);

            string idRace = Intent.GetStringExtra("id") ?? "Data not available";
            string Category = Intent.GetStringExtra("Category") ?? "Data not available";
            string Referee = Intent.GetStringExtra("Referee") ?? "Data not available";
            string Gender = Intent.GetStringExtra("Gender") ?? "Data not available";
            string PoolLength = Intent.GetStringExtra("PoolLength") ?? "Data not available";
            string RaceLength = Intent.GetStringExtra("RaceLength") ?? "Data not available";
            string Style = Intent.GetStringExtra("Style") ?? "Data not available";
            string Weekday = Intent.GetStringExtra("Weekday") ?? "Data not available";
            string Date = Intent.GetStringExtra("Date") ?? "Data not available";
            string TimeSpan = Intent.GetStringExtra("TimeSpan") ?? "Data not available";
            this.Title = Weekday + ", " + TimeSpan;


            /*
             * u UtrkaDetaljiLayout kreiraj Text polja i popuni ih s ovim podacima gore
            */


            swimmersTable = client.GetTable<SwimmerRaceView>();
            List<SwimmerRaceView> list = await swimmersTable
                .Where(e => e.IdRace == idRace)
                .OrderByDescending(e => e.Score)
                .ToListAsync();

            adapter = new UtrkaDetaljiAdapter(this, Resource.Layout.PlivaciUtrkaOsnovnoLayout);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = adapter;

            adapter.Clear();
            foreach (SwimmerRaceView current in list)
                adapter.Add(current);
        }
    }
}