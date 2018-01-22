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
using PlivanjeMobileApp.Activities;
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Adapters
{
    class ClubViewAdapter : BaseAdapter<ClubView>
    {
        Activity activity;
        int layoutResourceId;
        List<ClubView> items = new List<ClubView>();

        public ClubViewAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView largeText1;
            TextView mediumText1;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);

                largeText1 = row.FindViewById<TextView>(Resource.Id.largeText1);
                mediumText1 = row.FindViewById<TextView>(Resource.Id.mediumText1);

            }
            else
            {
                largeText1 = row.FindViewById<TextView>(Resource.Id.largeText1);
                mediumText1 = row.FindViewById<TextView>(Resource.Id.mediumText1);
            }

            largeText1.Text = currentItem.Name;
            mediumText1.Text = currentItem.Place;

            largeText1.Touch += delegate (object sender, View.TouchEventArgs e)  { SendClubData(sender, e, currentItem); };
            mediumText1.Touch += delegate (object sender, View.TouchEventArgs e) {  SendClubData(sender, e, currentItem); };

            return row;
        }

        private void SendClubData(object sender, View.TouchEventArgs e, ClubView club)
        {
            //System.Diagnostics.Debug.WriteLine("Touched " + e.Event.Action);
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(ClubDetailsActivity));
                activity2.PutExtra("id", club.Id);
                activity2.PutExtra("name", club.Name.Trim());
                activity2.PutExtra("place", club.Place.Trim());
                activity2.PutExtra("postalcode", club.PostalCode.Trim());
                activity.StartActivity(activity2);
            }
        }

        public void Add(ClubView item)
        {
            items.Add(item);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            items.Clear();
            NotifyDataSetChanged();
        }

        #region implemented abstract members of BaseAdapter

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override ClubView this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion

    }

    class ClubViewAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}