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
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "Kategorije plivača")]
    public class PlivaciActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";
        private IMobileServiceTable<Category> categoriesTable;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Plivaci);

            client = new MobileServiceClient(applicationURL);

            categoriesTable = client.GetTable<Category>();

            var list = await categoriesTable.ToListAsync();
            Dictionary<string, string> categories;

            categories = new Dictionary<string, string>();
            foreach (Category cat in list)
            {
                categories.Add(cat.Name.Trim(), cat.Id.Trim());
            }

            Button plivaciVeterani = FindViewById<Button>(Resource.Id.plivacivetbut);
            Button plivaciSeniori = FindViewById<Button>(Resource.Id.plivacisenbut);
            Button plivaciMladiSeniori = FindViewById<Button>(Resource.Id.plivacimsenbut);
            Button plivaciJuniori = FindViewById<Button>(Resource.Id.plivacijunbut);
            Button plivaciMladiJuniori = FindViewById<Button>(Resource.Id.plivacimjunbut);
            Button plivaciKadeti = FindViewById<Button>(Resource.Id.plivacikadbut);
            Button plivaciMladiKadeti = FindViewById<Button>(Resource.Id.plivacimkadbut);
            Button plivaciPocetnici = FindViewById<Button>(Resource.Id.plivacipocbut);

            var activity = new Intent(this, typeof(PlivaciPoKategorijiActivity));

            plivaciVeterani.Click += delegate {
                activity.PutExtra("label", "Veterani");
                activity.PutExtra("kategorija", categories["veterani"]);
                StartActivity(activity);
            };
            plivaciSeniori.Click += delegate {
                activity.PutExtra("label", "Seniori");
                activity.PutExtra("kategorija", categories["seniori"]);
                StartActivity(activity);
            };
            plivaciMladiSeniori.Click += delegate {
                activity.PutExtra("label", "Mlađi seniori");
                activity.PutExtra("kategorija", categories["mlađi seniori"]);
                StartActivity(activity);
            };
            plivaciJuniori.Click += delegate {
                activity.PutExtra("label", "Juniori");
                activity.PutExtra("kategorija", categories["juniori"]);
                StartActivity(activity);
            };
            plivaciMladiJuniori.Click += delegate {
                activity.PutExtra("label", "Mlađi juniori");
                activity.PutExtra("kategorija", categories["mlađi juniori"]);
                StartActivity(activity);
            };
            plivaciKadeti.Click += delegate {
                activity.PutExtra("label", "Kadeti");
                activity.PutExtra("kategorija", categories["kadeti"]);
                StartActivity(activity);
            };
            plivaciMladiKadeti.Click += delegate {
                activity.PutExtra("label", "Mlađi kadeti");
                activity.PutExtra("kategorija", categories["mlađi kadeti"]);
                StartActivity(activity);
            };
            plivaciPocetnici.Click += delegate {
                activity.PutExtra("label", "Početnici");
                activity.PutExtra("kategorija", categories["početnici"]);
                StartActivity(activity);
            };

        }
    }
}