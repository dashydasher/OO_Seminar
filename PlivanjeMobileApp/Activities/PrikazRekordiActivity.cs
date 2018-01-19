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
    [Activity(Label = "PrikazRekordiActivity")]
    public class PrikazRekordiActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private IMobileServiceTable<Record> recordTable;
        private PrikazRekordiAdapter adapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.ListViewLayout);

            string gender = Intent.GetStringExtra("gender") ?? "Data not available";

            if (gender == "m")
            {
                this.Title = "Muški rekordi";
            }
            else if (gender == "ž")
            {
                this.Title = "Ženski rekordi";
            }

            recordTable = client.GetTable<Record>();

            adapter = new PrikazRekordiAdapter(this, Resource.Layout.PrikazRekordiLayout);
            var listRecord = FindViewById<ListView>(Resource.Id.listViewLayout);
            listRecord.Adapter = adapter;

            recordTable = client.GetTable<Record>();

            var records = await recordTable
                .Where(e => e.Gender == gender)
                .OrderBy(e => e.Style)
                .ThenBy(e => e.Length)
                .ThenBy(e => e.Category)
                .ToListAsync();

            adapter.Clear();
            foreach (Record current in records)
                adapter.Add(current);
        }
    }
}