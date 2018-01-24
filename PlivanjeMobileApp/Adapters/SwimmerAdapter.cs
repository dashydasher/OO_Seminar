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
    class SwimmerAdapter : BaseAdapter<SwimmersView>
    {
        Activity activity;
        int layoutResourceId;
        List<SwimmersView> items = new List<SwimmersView>();

        public SwimmerAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView textArea1;
            TextView textArea2;
            TextView textArea3;
            TextView textArea4;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
            }
            textArea1 = row.FindViewById<TextView>(Resource.Id.textArea1);
            textArea2 = row.FindViewById<TextView>(Resource.Id.textArea2);
            textArea3 = row.FindViewById<TextView>(Resource.Id.textArea3);
            textArea4 = row.FindViewById<TextView>(Resource.Id.textArea4);

            textArea1.Text = currentItem.TimeStart.ToString("yyyy") + "-" + currentItem.TimeEnd.ToString("yyyy");
            textArea2.Text = currentItem.Category;
            textArea3.Text = currentItem.Club;
            textArea4.Text = currentItem.Score + " bodova";

            textArea1.Touch += delegate (object sender, View.TouchEventArgs e) { SendClubData(sender, e, currentItem); };
            textArea2.Touch += delegate (object sender, View.TouchEventArgs e) { SendClubData(sender, e, currentItem); };
            textArea3.Touch += delegate (object sender, View.TouchEventArgs e) { SendClubData(sender, e, currentItem); };
            textArea4.Touch += delegate (object sender, View.TouchEventArgs e) { SendClubData(sender, e, currentItem); };

            return row;
        }

        private void SendClubData(object sender, View.TouchEventArgs e, SwimmersView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(ClubDetailsActivity));
                activity2.PutExtra("id", currentItem.IdClub);
                activity2.PutExtra("name", currentItem.Club);
                activity2.PutExtra("place", currentItem.Place);
                activity2.PutExtra("postalcode", currentItem.PostalCode);
                activity.StartActivity(activity2);
            }
        }

        public void Add(SwimmersView item)
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

        public override SwimmersView this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion
    }
}