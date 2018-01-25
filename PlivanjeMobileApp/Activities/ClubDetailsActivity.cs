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
    [Activity(Label = "Klub - Plivači")]
    public class ClubDetailsActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private IMobileServiceTable<Season> seasonsTable;
        private ClubSwimmersAdapter plivaciAdapter;
        private ArrayAdapter<string> spinnerAdapter;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";
        private List<KeyValuePair<string, string>> seasonToDisplay;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ClubDetailsLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string id = Intent.GetStringExtra("id") ?? "Data not available";
            string name = Intent.GetStringExtra("name") ?? "Data not available";
            string place = Intent.GetStringExtra("place") ?? "Data not available";
            string postalcode = Intent.GetStringExtra("postalcode") ?? "Data not available";

            var textView = FindViewById<TextView>(Resource.Id.nazivKluba);
            var textView2 = FindViewById<TextView>(Resource.Id.mjesto);
            textView.Text = name;
            textView2.Text = postalcode + "   " + place;

            this.Title = name.Replace("Plivački", "P").Replace(" klub", "K");

            client = new MobileServiceClient(applicationURL);

            swimmersTable = client.GetTable<SwimmersView>();

            plivaciAdapter = new ClubSwimmersAdapter(this, Resource.Layout.ClubSwimmerLayout);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.plivaci);
            listViewClubSwimmers.Adapter = plivaciAdapter;

            seasonsTable = client.GetTable<Season>();

            var seasons = await seasonsTable
                .OrderByDescending(e => e.TimeStart)
                .ToListAsync();

            List<string> seasonNames = new List<string>();
            seasonToDisplay = new List<KeyValuePair<string, string>>();
            foreach (Season current in seasons)
            {
                seasonToDisplay.Add(new KeyValuePair<string, string>(current.TimeStart.ToString("yyyy") + "-" + current.TimeEnd.ToString("yyyy"), current.Id.ToString()));
                seasonNames.Add(current.TimeStart.ToString("yyyy") + "-" + current.TimeEnd.ToString("yyyy"));
            }

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += delegate (object sender, AdapterView.ItemSelectedEventArgs e)
            {
                FillAdapterWithData(plivaciAdapter, swimmersTable, id, seasonToDisplay[e.Position].Value);
            };

            spinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, seasonNames);
            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = spinnerAdapter;
        }

        private async void FillAdapterWithData(ClubSwimmersAdapter adapter, IMobileServiceTable<SwimmersView> swimmersTable, string clubId, string seasonId = null)
        {
            List<SwimmersView> list = await swimmersTable
                    .Where(e => e.IdClub == clubId)
                    .Where(e => e.IdSeason == seasonId)
                    .ToListAsync();
            adapter.Clear();
            foreach (SwimmersView current in list)
                adapter.Add(current);
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