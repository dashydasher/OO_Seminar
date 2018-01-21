using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    [Activity(Label = "Rezultati pretrage")]
    public class SearchActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private ClubSwimmersAdapter adapter;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.SearchResultsLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string pretrazujem = Intent.GetStringExtra("pretrazujem") ?? "Data not available";

            swimmersTable = client.GetTable<SwimmersView>();

            adapter = new ClubSwimmersAdapter(this, Resource.Layout.ClubSwimmerLayout);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.plivaci);
            listViewClubSwimmers.Adapter = adapter;

            var swimmers = await swimmersTable
                .Where(e => e.TimeStart.Year == DateTime.Today.Year)
                .ToListAsync();

            adapter.Clear();
            string rezultati = "";
            foreach (SwimmersView current in swimmers)
            {
                if (
                    Regex.IsMatch((current.LastName.Trim() + " " + current.FirstName.Trim()).ToLower(), ".*" + pretrazujem.ToLower() + ".*")
                    ||
                    Regex.IsMatch((current.FirstName.Trim() + " " + current.LastName.Trim()).ToLower(), ".*" + pretrazujem.ToLower() + ".*")
                    )
                {
                    rezultati += current.LastName.Trim() + " " + current.FirstName.Trim() + "\n";
                    adapter.Add(current);
                }
            }

            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = "Rezultati za \"" + pretrazujem + "\":";
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