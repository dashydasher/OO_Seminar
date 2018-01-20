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
    [Activity(Label = "NatjecanjaActivity")]
    public class NatjecanjaActivity : Activity
    {
        ProgressBar progressBar;
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private IMobileServiceTable<CompetitionView> competitionTable;
        private NatjecanjaAdapter adapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.ListViewLayout);

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);

            this.Title = "Natjecanja";

            competitionTable = client.GetTable<CompetitionView>();

            adapter = new NatjecanjaAdapter(this, Resource.Layout.NatjecanjaLayout);
            var listCompetition = FindViewById<ListView>(Resource.Id.listViewLayout);
            listCompetition.Adapter = adapter;

            competitionTable = client.GetTable<CompetitionView>();

            var competitions = await competitionTable
                .OrderByDescending(e => e.TimeStart)
                .Take(50)
                .ToListAsync();

            adapter.Clear();
            foreach (CompetitionView current in competitions)
                adapter.Add(current);

            progressBar.Visibility = ViewStates.Gone;
        }
    }
}