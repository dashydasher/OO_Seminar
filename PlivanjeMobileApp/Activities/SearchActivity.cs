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
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "Rezultati pretrage")]
    public class SearchActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private IMobileServiceTable<SwimmersView> swimmersTable;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            client = new MobileServiceClient(applicationURL);

            SetContentView(Resource.Layout.SearchResultsLayout);

            string pretrazujem = Intent.GetStringExtra("pretrazujem") ?? "Data not available";

            swimmersTable = client.GetTable<SwimmersView>();

            var swimmers = await swimmersTable
                .Where(e => e.TimeStart.Year == DateTime.Today.Year)
                .ToListAsync();

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
                }
            }

            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = "Rezultati za \"" + pretrazujem + "\":";


        }
    }
}