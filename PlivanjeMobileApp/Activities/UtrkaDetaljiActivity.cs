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
using PlivanjeMobileApp.Helpers;
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "UtrkaDetaljiActivity")]
    public class UtrkaDetaljiActivity : Activity
    {
        private IMobileServiceTable<SwimmerRaceView> swimmersTable;
        private MobileServiceClient client;
        private UtrkaDetaljiAdapter adapter;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.UtrkaDetaljiLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string idRace = Intent.GetStringExtra("id") ?? "Data not available";
            string Category = Intent.GetStringExtra("Category") ?? "Data not available";
            string Referee = Intent.GetStringExtra("Referee") ?? "Data not available";
            string Gender = Intent.GetStringExtra("Gender") ?? "Data not available";
            string RaceLength = Intent.GetStringExtra("RaceLength") ?? "Data not available";
            string Style = Intent.GetStringExtra("Style") ?? "Data not available";
            string Weekday = Intent.GetStringExtra("Weekday") ?? "Data not available";
            string Date = Intent.GetStringExtra("Date") ?? "Data not available";
            string TimeSpan = Intent.GetStringExtra("TimeSpan") ?? "Data not available";
            this.Title = Weekday + ", " + TimeSpan;

            TextView textArea1 = FindViewById<TextView>(Resource.Id.textArea1);
            TextView textArea2 = FindViewById<TextView>(Resource.Id.textArea2);
            TextView textArea3 = FindViewById<TextView>(Resource.Id.textArea3);

            textArea1.Text = Gender + " " + Category;
            textArea2.Text = RaceLength + "m " + Style;
            textArea3.Text = "Sudi: " + Referee;

            swimmersTable = client.GetTable<SwimmerRaceView>();
            List<SwimmerRaceView> list = await swimmersTable.ToListAsync();

            adapter = new UtrkaDetaljiAdapter(this, Resource.Layout.PlivaciUtrkaOsnovnoLayout, isUtrkaLayout:true);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = adapter;

            adapter.Clear();
            foreach (SwimmerRaceView current in list.OrderByDescending(e => e.Score))
            {
                if (current.IdRace == idRace)
                {
                    adapter.Add(current);
                }
            }
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
    }
}