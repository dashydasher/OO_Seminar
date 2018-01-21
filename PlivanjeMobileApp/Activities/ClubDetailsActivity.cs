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
    [Activity(Label = "Klub - Plivači")]
    public class ClubDetailsActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private IMobileServiceTable<Season> seasonsTable;
        private ClubSwimmersAdapter adapter;
        private ArrayAdapter<string> adapter2;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
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
            textView.Text = name;
            var textView2 = FindViewById<TextView>(Resource.Id.mjesto);
            textView2.Text = postalcode + "   " + place;

            var newName = name.Replace("Plivački", "P").Replace(" klub", "K").Trim();
            this.Title = newName;

            CurrentPlatform.Init();

            client = new MobileServiceClient(applicationURL);

            swimmersTable = client.GetTable<SwimmersView>();

            adapter = new ClubSwimmersAdapter(this, Resource.Layout.ClubSwimmerLayout);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.plivaci);
            listViewClubSwimmers.Adapter = adapter;

            seasonsTable = client.GetTable<Season>();

            var seasons = await seasonsTable.OrderByDescending(e => e.TimeStart).ToListAsync();

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
                FillAdapterWithData(adapter, swimmersTable, id, seasonToDisplay[e.Position].Value);
            };

            adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, seasonNames);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter2;
        }

        private async void FillAdapterWithData(ClubSwimmersAdapter adapter, IMobileServiceTable<SwimmersView> swimmersTable, string clubId, string seasonId = null)
        {
            List<SwimmersView> list;
            if (seasonId != null)
            {
                list = await swimmersTable
                    .Where(e => e.IdClub == clubId)
                    .Where(e => e.IdSeason == seasonId)
                    .ToListAsync();
            }
            else
            {
                list = await swimmersTable
                    .Where(e => e.IdClub == clubId)
                    .ToListAsync();
            }
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