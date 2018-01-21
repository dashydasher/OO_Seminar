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
    class NatjecanjeDetaljiAdapter : BaseAdapter<RaceView>
    {

        Activity activity;
        int layoutResourceId;
        List<RaceView> items = new List<RaceView>();

        public NatjecanjeDetaljiAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView timeStart;
            TextView gender;
            TextView raceLength;
            TextView style;
            TextView category;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                category = row.FindViewById<TextView>(Resource.Id.textArea1);
                gender = row.FindViewById<TextView>(Resource.Id.textArea2);
                style = row.FindViewById<TextView>(Resource.Id.textArea3);
                raceLength = row.FindViewById<TextView>(Resource.Id.textArea4);
                timeStart = row.FindViewById<TextView>(Resource.Id.textArea5);
            }
            else
            {
                category = row.FindViewById<TextView>(Resource.Id.textArea1);
                gender = row.FindViewById<TextView>(Resource.Id.textArea2);
                style = row.FindViewById<TextView>(Resource.Id.textArea3);
                raceLength = row.FindViewById<TextView>(Resource.Id.textArea4);
                timeStart = row.FindViewById<TextView>(Resource.Id.textArea5);
            }
            category.Text = currentItem.Category;
            gender.Text = currentItem.Gender;
            style.Text = currentItem.Style;
            raceLength.Text = currentItem.RaceLength.ToString().Trim() + "m";
            timeStart.Text = currentItem.TimeStart.ToUniversalTime().ToString("dd.MM.yyyy. H:mm") + "h";

            category.Touch += delegate (object sender, View.TouchEventArgs e) { SendRaceData(sender, e, currentItem); };
            gender.Touch += delegate (object sender, View.TouchEventArgs e) { SendRaceData(sender, e, currentItem); };
            style.Touch += delegate (object sender, View.TouchEventArgs e) { SendRaceData(sender, e, currentItem); };
            raceLength.Touch += delegate (object sender, View.TouchEventArgs e) { SendRaceData(sender, e, currentItem); };
            timeStart.Touch += delegate (object sender, View.TouchEventArgs e) { SendRaceData(sender, e, currentItem); };

            return row;
        }

        private void SendRaceData(object sender, View.TouchEventArgs e, RaceView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(UtrkaDetaljiActivity));
                activity2.PutExtra("id", currentItem.Id);
                activity2.PutExtra("Category", currentItem.Category.Trim());
                activity2.PutExtra("Referee", currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim());
                activity2.PutExtra("Gender", currentItem.Gender.Trim());
                activity2.PutExtra("PoolLength", currentItem.PoolLength.ToString());
                activity2.PutExtra("RaceLength", currentItem.RaceLength.ToString());
                activity2.PutExtra("Style", currentItem.Style.Trim());
                activity2.PutExtra("Weekday", currentItem.TimeStart.ToUniversalTime().ToString("dddd"));
                activity2.PutExtra("Date", currentItem.TimeStart.ToUniversalTime().ToString("dd.MM.yyyy."));
                activity2.PutExtra("TimeSpan", currentItem.TimeStart.ToUniversalTime().ToString("H:mm") + "-" + currentItem.TimeEnd.ToUniversalTime().ToString("H:mm"));
                activity.StartActivity(activity2);
            }
        }

        public void Add(RaceView item)
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

        public override RaceView this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion

    }

    class NatjecanjeDetaljiAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}