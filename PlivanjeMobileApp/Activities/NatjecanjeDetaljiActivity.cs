﻿using System;
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
    [Activity(Label = "NatjecanjeDetaljiActivity")]
    public class NatjecanjeDetaljiActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<RaceView> racesTable;
        private IMobileServiceTable<CompetitionView> competitionsTable;
        private NatjecanjeDetaljiAdapter adapter;
        private string idCompetition;
        private string name;
        private string timeStart;
        private string timeEnd;
        private string hallName;
        private string address;
        private string placeName;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NatjecanjeDetaljiLayout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            client = new MobileServiceClient(applicationURL);

            idCompetition = Intent.GetStringExtra("id") ?? "Data not available";
            name = Intent.GetStringExtra("name") ?? "Data not available";
            if (name != "Data not available")
            {
                timeStart = Intent.GetStringExtra("timeStart") ?? "Data not available";
                timeEnd = Intent.GetStringExtra("timeEnd") ?? "Data not available";
                address = Intent.GetStringExtra("address") ?? "Data not available";
                hallName = Intent.GetStringExtra("hallName") ?? "Data not available";
                placeName = Intent.GetStringExtra("placeName") ?? "Data not available";
            }
            else
            {
                competitionsTable = client.GetTable<CompetitionView>();
                List<CompetitionView> list2 = await competitionsTable.Where(e => e.Id == idCompetition).ToListAsync();
                CompetitionView competition = list2.First();
                name = competition.Name;
                timeStart = competition.TimeStart.ToString("dddd dd.MM.yyyy");
                timeEnd = competition.TimeEnd.ToString("dddd dd.MM.yyyy");
                address = competition.Address;
                hallName = competition.HallName;
                placeName = competition.PlaceName;
            }
            this.Title = name;

            TextView textArea1 = FindViewById<TextView>(Resource.Id.textArea1);
            TextView textArea2 = FindViewById<TextView>(Resource.Id.textArea2);
            TextView textArea3 = FindViewById<TextView>(Resource.Id.textArea3);
            TextView textArea4 = FindViewById<TextView>(Resource.Id.textArea4);

            textArea1.Text = "Od: " + timeStart;
            textArea2.Text = "Do: " + timeEnd;
            textArea3.Text = "Dvorana: " + hallName.Trim();
            textArea4.Text = address.Trim() + ", " + placeName.Trim();


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