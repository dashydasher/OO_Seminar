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
using PlivanjeMobileApp.Helpers;
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Activities
{
    [Activity(Label = "Kategorije plivača")]
    public class PlivaciActivity : Activity
    {
        private MobileServiceClient client;
        const string applicationURL = @"https://oosemmobapp2.azurewebsites.net";
        private IMobileServiceTable<Category> categoriesTable;
        private IMobileServiceTable<SwimmersView> swimmersTable;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new MobileServiceClient(applicationURL);
            SetContentView(Resource.Layout.Plivaci);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            categoriesTable = client.GetTable<Category>();

            var list = await categoriesTable.ToListAsync();
            Dictionary<string, string> categoriesDict;

            categoriesDict = new Dictionary<string, string>();
            foreach (Category cat in list)
            {
                categoriesDict.Add(cat.Name.Trim(), cat.Id.Trim());
            }

            swimmersTable = client.GetTable<SwimmersView>();
            var swimmers = await swimmersTable.ToListAsync();

            List<string> swimmerNames = new List<string>();
            foreach (SwimmersView current in swimmers)
            {
                if (current.TimeStart.Year == DateTime.Today.Year)
                {
                    swimmerNames.Add(current.FirstName.Trim() + " " + current.LastName.Trim());
                }
            }

            AutoCompleteTextView textView = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete_plivac);
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.searchListItem, swimmerNames);

            textView.Adapter = adapter;
            Button searchButton = FindViewById<Button>(Resource.Id.searchbut);

            var searchactivity = new Intent(this, typeof(SearchActivity));
            searchButton.Click += delegate {
                searchactivity.PutExtra("pretrazujem", textView.Text);
                StartActivity(searchactivity);
            };

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
                StartActvityAndAddData("Veterani", categoriesDict["veterani"], activity);
            };
            plivaciSeniori.Click += delegate {
                StartActvityAndAddData("Seniori", categoriesDict["seniori"], activity);
            };
            plivaciMladiSeniori.Click += delegate {
                StartActvityAndAddData("Mlađi seniori", categoriesDict["mlađi seniori"], activity);
            };
            plivaciJuniori.Click += delegate {
                StartActvityAndAddData("Juniori", categoriesDict["juniori"], activity);
            };
            plivaciMladiJuniori.Click += delegate {
                StartActvityAndAddData("Mlađi juniori", categoriesDict["mlađi juniori"], activity);
            };
            plivaciKadeti.Click += delegate {
                StartActvityAndAddData("Kadeti", categoriesDict["kadeti"], activity);
            };
            plivaciMladiKadeti.Click += delegate {
                StartActvityAndAddData("Mlađi kadeti", categoriesDict["mlađi kadeti"], activity);
            };
            plivaciPocetnici.Click += delegate {
                StartActvityAndAddData("Početnici", categoriesDict["početnici"], activity);
            };
        }

        private void StartActvityAndAddData(string title, string categoryId, Intent activity)
        {
            activity.PutExtra("label", title);
            activity.PutExtra("kategorija", categoryId);
            StartActivity(activity);
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