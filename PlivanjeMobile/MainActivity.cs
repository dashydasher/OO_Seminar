using System;
using Android.OS;
using Android.App;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PlivanjeMobile.Models;

namespace PlivanjeMobile
{
    [Activity(Label = "PlivanjeMobile", MainLauncher = true)]
    public class MainActivity : Activity
    {
        // Client reference.
        private MobileServiceClient client;

        private IMobileServiceTable<Place> placeTable;

        // URL of the mobile app backend.
        const string applicationURL = @"https://oosemmobapp.azurewebsites.net";

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.OneText);

            CurrentPlatform.Init();

            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.textView1);

            // Create the client instance, using the mobile app backend URL.
            client = new MobileServiceClient(applicationURL);

            placeTable = client.GetTable<Place>();


            var list = await placeTable.ToListAsync();

            string nazivi = "Slijede nazivi:\n";
            foreach (Place current in list)
            {
                nazivi += current.Name + current.PostalCode;
            }

            translatedPhoneWord.Text = nazivi;
        }
    }
}

