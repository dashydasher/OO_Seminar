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
    [Activity(Label = "RekordiActivity")]
    public class RekordiActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Rekordi);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbarIncluded);
            SetActionBar(toolbar);

            this.Title = "Rekordi";

            Button muskiButton = FindViewById<Button>(Resource.Id.rekordimbut);
            Button zenskiButton = FindViewById<Button>(Resource.Id.rekordizbut);

            var activity = new Intent(this, typeof(PrikazRekordiActivity));

            muskiButton.Click += delegate {
                activity.PutExtra("gender", "m");
                StartActivity(activity);
            };
            zenskiButton.Click += delegate {
                activity.PutExtra("gender", "ž");
                StartActivity(activity);
            };
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