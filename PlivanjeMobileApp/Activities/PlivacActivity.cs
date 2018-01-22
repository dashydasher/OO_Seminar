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
        private SwimmerAdapter adapter;
        private UtrkaDetaljiAdapter adapter2;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.Plivac);

            var sezonebutton = FindViewById<Button>(Resource.Id.sezonebutton);
            var utrkebutton = FindViewById<Button>(Resource.Id.utrkebutton);

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

            List<SwimmersView> list = await swimmersTable.Where(e => e.Id == idPlivaca).ToListAsync();
            List<SwimmerRaceView> list2 = await swimmerRacesTable.Where(e => e.IdSwimmer == idPlivaca).ToListAsync();

            adapter = new SwimmerAdapter(this, Resource.Layout.SezonaPlivaca);
            var listView = FindViewById<ListView>(Resource.Id.sezone);
            listView.Adapter = adapter;

            adapter2 = new UtrkaDetaljiAdapter(this, Resource.Layout.PlivaciUtrkaOsnovnoLayout, isUtrkaLayout:false);

            adapter.Clear();
            foreach (SwimmersView current in list)
                adapter.Add(current);

            TextView rezultati = FindViewById<TextView>(Resource.Id.rezultati);
            sezonebutton.Click += delegate {
                rezultati.Text = "Rezultati po sezonama";

                adapter2.Clear();
                listView.Adapter = adapter;
                adapter.Clear();

                foreach (SwimmersView current in list)
                    adapter.Add(current);
            };
            utrkebutton.Click += delegate {
                rezultati.Text = "Rezultati po utrkama";

                adapter.Clear();
                listView.Adapter = adapter2;
                adapter2.Clear();

                foreach (SwimmerRaceView current in list2)
                    adapter2.Add(current);
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