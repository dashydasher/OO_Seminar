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
    [Activity(Label = "Rekordi")]
    public class PrikazRekordiActivity : Activity
    {
        ProgressBar progressBar;
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";
        private IMobileServiceTable<Record> recordTable;
        private PrikazRekordiAdapter adapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.ListViewLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string gender = Intent.GetStringExtra("gender") ?? "Data not available";
            if (gender == "m")
            {
                this.Title = "Muški rekordi";
            }
            else if (gender == "ž")
            {
                this.Title = "Ženski rekordi";
            }

            adapter = new PrikazRekordiAdapter(this, Resource.Layout.PrikazRekordiLayout);
            var listRecord = FindViewById<ListView>(Resource.Id.listViewLayout);
            listRecord.Adapter = adapter;

            recordTable = client.GetTable<Record>();

            var records = await recordTable
                .OrderBy(e => e.Style)
                .ThenBy(e => e.Length)
                .ThenBy(e => e.Category)
                .ToListAsync();

            adapter.Clear();
            foreach (Record current in records)
                if (current.Gender.ToLower().Equals(gender.ToLower()))
                {
                    adapter.Add(current);
                }
                

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            progressBar.Visibility = ViewStates.Gone;
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