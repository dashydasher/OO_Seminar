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
    [Activity(Label = "Natjecanje")]
    public class NatjecanjeDetaljiActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<RaceView> racesTable;
        private IMobileServiceTable<CompetitionView> competitionsTable;
        private NatjecanjeDetaljiAdapter adapter;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NatjecanjeDetaljiLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            client = new MobileServiceClient(applicationURL);

            string idCompetition = Intent.GetStringExtra("id") ?? "Data not available";
            competitionsTable = client.GetTable<CompetitionView>();
            List<CompetitionView> natjecanjaList = await competitionsTable.Where(e => e.Id == idCompetition).ToListAsync();
            CompetitionView competition = natjecanjaList.FirstOrDefault();

            string name = competition.Name.Trim();
            string timeStart = competition.TimeStart.ToString("dddd dd.MM.yyyy");
            string timeEnd = competition.TimeEnd.ToString("dddd dd.MM.yyyy");
            string address = competition.Address.Trim();
            string hallName = competition.HallName.Trim();
            string placeName = competition.PlaceName.Trim();
            this.Title = name;

            TextView textArea1 = FindViewById<TextView>(Resource.Id.textArea1);
            TextView textArea2 = FindViewById<TextView>(Resource.Id.textArea2);
            TextView textArea3 = FindViewById<TextView>(Resource.Id.textArea3);
            TextView textArea4 = FindViewById<TextView>(Resource.Id.textArea4);

            textArea1.Text = "Od: " + timeStart;
            textArea2.Text = "Do: " + timeEnd;
            textArea3.Text = "Dvorana: " + hallName;
            textArea4.Text = address + ", " + placeName;

            racesTable = client.GetTable<RaceView>();
            List<RaceView> list = await racesTable
                .Where(e => e.IdCompetition == idCompetition)
                .OrderByDescending(e => e.TimeStart)
                .ToListAsync();

            adapter = new NatjecanjeDetaljiAdapter(this, Resource.Layout.UtrkaOsnovnoLayout);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = adapter;

            adapter.Clear();
            foreach (RaceView current in list)
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