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

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.TitleFormatted.ToString())
            {
                case "Natjecanja":
                    StartActivity(typeof(NatjecanjaActivity));
                    break;
                case "Klubovi":
                    StartActivity(typeof(KluboviActivity));
                    break;
                case "Plivači":
                    StartActivity(typeof(PlivaciActivity));
                    break;
                case "Rekordi":
                    StartActivity(typeof(RekordiActivity));
                    break;
                case "Početna":
                    StartActivity(typeof(MainActivity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}