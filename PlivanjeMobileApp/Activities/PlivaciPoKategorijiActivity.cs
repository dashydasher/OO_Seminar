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
    [Activity(Label = "Plivači")]
    public class PlivaciPoKategorijiActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private IMobileServiceTable<Season> seasonsTable;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";
        private ClubSwimmersAdapter swimmersAdapter;
        private ArrayAdapter<string> spinnerAdapter;
        private List<KeyValuePair<string, string>> seasonsToDisplay;
        private ProgressBar progressBar;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.PregledPlivaca);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string categoryId = Intent.GetStringExtra("kategorija") ?? "Data not available";
            string label = Intent.GetStringExtra("label") ?? "Data not available";
            this.Title = label;

            swimmersTable = client.GetTable<SwimmersView>();

            swimmersAdapter = new ClubSwimmersAdapter(this, Resource.Layout.ClubSwimmerLayout);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.plivaci);
            listViewClubSwimmers.Adapter = swimmersAdapter;

            seasonsTable = client.GetTable<Season>();
            var seasons = await seasonsTable.OrderByDescending(e => e.TimeStart).ToListAsync();

            List<string> seasonNames = new List<string>();
            seasonsToDisplay = new List<KeyValuePair<string, string>>();
            foreach (Season current in seasons)
            {
                seasonsToDisplay.Add(new KeyValuePair<string, string>(current.TimeStart.ToString("yyyy") + "-" + current.TimeEnd.ToString("yyyy"), current.Id.ToString()));
                seasonNames.Add(current.TimeStart.ToString("yyyy") + "-" + current.TimeEnd.ToString("yyyy"));
            }

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            spinner.ItemSelected += delegate (object sender, AdapterView.ItemSelectedEventArgs e)
            {
                FillAdapterWithData(swimmersAdapter, swimmersTable, categoryId, seasonsToDisplay[e.Position].Value);
            };

            spinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, seasonNames);
            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = spinnerAdapter;

            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            progressBar.Visibility = ViewStates.Gone;
        }

        private async void FillAdapterWithData(ClubSwimmersAdapter adapter, IMobileServiceTable<SwimmersView> swimmersTable, string catId, string seasonId)
        {
            List<SwimmersView> list = await swimmersTable
                    .Where(e => e.IdCategory == catId)
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