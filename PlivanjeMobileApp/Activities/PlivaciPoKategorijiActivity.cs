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
    [Activity(Label = "Plivači")]
    public class PlivaciPoKategorijiActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<ClubSwimmerView> swimmersTable;
        private IMobileServiceTable<Season> seasonsTable;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private ClubSwimmersAdapter adapter;
        private ArrayAdapter<string> adapter2;
        private List<KeyValuePair<string, string>> seasonToDisplay;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.PregledPlivaca);

            string catId = Intent.GetStringExtra("kategorija") ?? "Data not available";
            string label = Intent.GetStringExtra("label") ?? "Data not available";
            this.Title = label;

            swimmersTable = client.GetTable<ClubSwimmerView>();

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
                FillAdapterWithData(adapter, swimmersTable, catId, seasonToDisplay[e.Position].Value);
            };

            adapter2 = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, seasonNames);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter2;
        }

        private async void FillAdapterWithData(ClubSwimmersAdapter adapter, IMobileServiceTable<ClubSwimmerView> swimmersTable, string catId, string seasonId)
        {
            List<ClubSwimmerView> list;
            if (seasonId != null)
            {
                list = await swimmersTable
                    .Where(e => e.IdCategory == catId)
                    .Where(e => e.IdSeason == seasonId)
                    .ToListAsync();
            }
            else
            {
                list = await swimmersTable
                    .Where(e => e.IdCategory == catId)
                    .ToListAsync();
            }
            adapter.Clear();
            foreach (ClubSwimmerView current in list)
                adapter.Add(current);
        }
    }
}