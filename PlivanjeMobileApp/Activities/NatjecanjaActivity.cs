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
    [Activity(Label = "Natjecanja")]
    public class NatjecanjaActivity : Activity
    {
        ProgressBar progressBar;
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";
        private IMobileServiceTable<CompetitionView> competitionTable;
        private NatjecanjaAdapter adapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.ListViewLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            adapter = new NatjecanjaAdapter(this, Resource.Layout.NatjecanjaLayout);
            var listCompetition = FindViewById<ListView>(Resource.Id.listViewLayout);
            listCompetition.Adapter = adapter;

            competitionTable = client.GetTable<CompetitionView>();
            var competitions = await competitionTable.ToListAsync();

            adapter.Clear();
            foreach (CompetitionView current in competitions.OrderByDescending(e => e.TimeStart).Take(50))
                adapter.Add(current);

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