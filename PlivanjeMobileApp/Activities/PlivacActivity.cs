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
    [Activity(Label = "PlivacActivity")]
    public class PlivacActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private SwimmerAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.Plivac);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            string idPlivaca = Intent.GetStringExtra("id") ?? "Data not available";
            string gender = Intent.GetStringExtra("gender") ?? "Data not available";
            string dateOfBirth = Intent.GetStringExtra("dateOfBirth") ?? "Data not available";
            string label = Intent.GetStringExtra("label") ?? "Data not available";
            this.Title = label.Trim() + ", " + gender;

            TextView spol = FindViewById<TextView>(Resource.Id.podaci);
            spol.Text = "Datum rođenja: " + dateOfBirth.Trim();

            swimmersTable = client.GetTable<SwimmersView>();

            List<SwimmersView> list = await swimmersTable.Where(e => e.Id == idPlivaca).ToListAsync();

            adapter = new SwimmerAdapter(this, Resource.Layout.SezonaPlivaca);
            var listViewClubSwimmers = FindViewById<ListView>(Resource.Id.sezone);
            listViewClubSwimmers.Adapter = adapter;

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