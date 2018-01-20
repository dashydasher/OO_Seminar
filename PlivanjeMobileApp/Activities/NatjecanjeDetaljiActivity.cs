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
    [Activity(Label = "NatjecanjeDetaljiActivity")]
    public class NatjecanjeDetaljiActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<RaceView> racesTable;
        private NatjecanjeDetaljiAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NatjecanjeDetaljiLayout);

            client = new MobileServiceClient(applicationURL);

            string idCompetition = Intent.GetStringExtra("id") ?? "Data not available";
            string name = Intent.GetStringExtra("name") ?? "Data not available";
            string timeStart = Intent.GetStringExtra("timeStart") ?? "Data not available";
            string timeEnd = Intent.GetStringExtra("timeEnd") ?? "Data not available";
            string address = Intent.GetStringExtra("address") ?? "Data not available";
            string hallName = Intent.GetStringExtra("hallName") ?? "Data not available";
            string placeName = Intent.GetStringExtra("placeName") ?? "Data not available";
            this.Title = name;

            TextView textArea1 = FindViewById<TextView>(Resource.Id.textArea1);
            TextView textArea2 = FindViewById<TextView>(Resource.Id.textArea2);
            TextView textArea3 = FindViewById<TextView>(Resource.Id.textArea3);
            TextView textArea4 = FindViewById<TextView>(Resource.Id.textArea4);

            textArea1.Text = "Od: " + timeStart;
            textArea2.Text = "Do: " + timeEnd;
            textArea3.Text = "Dvorana: " + hallName;
            textArea4.Text = address + ", " + placeName;


            racesTable = client.GetTable<RaceView>();
            List<RaceView> list = await racesTable
                .Where(e => e.IdCompetition == idCompetition)
                .OrderByDescending(e => e.TimeStart)
                .ToListAsync();

            adapter = new NatjecanjeDetaljiAdapter(this, Resource.Layout.UtrkaOsnovnoLayout);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = adapter;

            adapter.Clear();
            foreach (RaceView current in list)
                adapter.Add(current);
        }
    }
}