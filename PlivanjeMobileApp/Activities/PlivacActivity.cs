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
    [Activity(Label = "PlivacActivity")]
    public class PlivacActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<SwimmersView> swimmersTable;
        private IMobileServiceTable<SwimmerRaceView> swimmerRacesTable;
        private SwimmerAdapter swimmerAdapter;
        private UtrkaDetaljiAdapter utrkaAdapter;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Plivac);
            client = new MobileServiceClient(applicationURL);

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
            swimmerRacesTable = client.GetTable<SwimmerRaceView>();

            List<SwimmersView> swimmers = await swimmersTable.Where(e => e.IdSwimmer == idPlivaca).ToListAsync();
            List<SwimmerRaceView> swimmerRaces = await swimmerRacesTable.Where(e => e.IdSwimmer == idPlivaca).ToListAsync();

            swimmerAdapter = new SwimmerAdapter(this, Resource.Layout.SezonaPlivaca);
            var listView = FindViewById<ListView>(Resource.Id.sezone);
            listView.Adapter = swimmerAdapter;

            utrkaAdapter = new UtrkaDetaljiAdapter(this, Resource.Layout.PlivaciUtrkaOsnovnoLayout, isUtrkaLayout:false);

            swimmerAdapter.Clear();
            foreach (SwimmersView current in swimmers)
                swimmerAdapter.Add(current);

            TextView rezultati = FindViewById<TextView>(Resource.Id.rezultati);
            Button sezonebutton = FindViewById<Button>(Resource.Id.sezonebutton);
            Button utrkebutton = FindViewById<Button>(Resource.Id.utrkebutton);

            sezonebutton.Click += delegate {
                rezultati.Text = "Rezultati po sezonama";

                utrkaAdapter.Clear();
                listView.Adapter = swimmerAdapter;
                swimmerAdapter.Clear();
                foreach (SwimmersView current in swimmers)
                    swimmerAdapter.Add(current);
            };
            utrkebutton.Click += delegate {
                rezultati.Text = "Rezultati po utrkama";

                swimmerAdapter.Clear();
                listView.Adapter = utrkaAdapter;
                utrkaAdapter.Clear();
                foreach (SwimmerRaceView current in swimmerRaces)
                    utrkaAdapter.Add(current);
            };
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