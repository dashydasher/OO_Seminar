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
    class UtrkaDetaljiAdapter : BaseAdapter<SwimmerRaceView>
    {
        Activity activity;
        int layoutResourceId;
        List<SwimmerRaceView> items = new List<SwimmerRaceView>();
        bool isUtrkaLayout;

        public UtrkaDetaljiAdapter(Activity activity, int layoutResourceId, bool isUtrkaLayout)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
            this.isUtrkaLayout = isUtrkaLayout;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView RaceTime;
            TextView Swimmer;
            TextView Score;
            TextView Length;
            TextView Style;
            TextView RaceTime2;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                RaceTime = row.FindViewById<TextView>(Resource.Id.textArea1);
                Swimmer = row.FindViewById<TextView>(Resource.Id.textArea2);
                Score = row.FindViewById<TextView>(Resource.Id.textArea3);
                Length = row.FindViewById<TextView>(Resource.Id.textArea4);
                Style = row.FindViewById<TextView>(Resource.Id.textArea5);
                RaceTime2 = row.FindViewById<TextView>(Resource.Id.textArea6);
            }
            else
            {
                RaceTime = row.FindViewById<TextView>(Resource.Id.textArea1);
                Swimmer = row.FindViewById<TextView>(Resource.Id.textArea2);
                Score = row.FindViewById<TextView>(Resource.Id.textArea3);
                Length = row.FindViewById<TextView>(Resource.Id.textArea4);
                Style = row.FindViewById<TextView>(Resource.Id.textArea5);
                RaceTime2 = row.FindViewById<TextView>(Resource.Id.textArea6);
            }

            if (isUtrkaLayout)
            {
                RaceTime.Text = currentItem.RaceTime.ToUniversalTime().TimeOfDay.ToString().Trim();
                Swimmer.Text = currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim();
                Score.Text = "bod: " + currentItem.Score;
                Length.Visibility = ViewStates.Gone;
                Style.Visibility = ViewStates.Gone;
                RaceTime2.Visibility = ViewStates.Gone;

                RaceTime.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };
                Swimmer.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };
                Score.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };
            }
            else
            {
                RaceTime.Visibility = ViewStates.Gone;
                Swimmer.Visibility = ViewStates.Gone;
                Score.Visibility = ViewStates.Gone;
                Length.Text = currentItem.Length + "m " + currentItem.Style;
                Style.Text = currentItem.Time.ToUniversalTime().ToString("dd.MM.yyyy.");
                RaceTime2.Text = currentItem.RaceTime.ToUniversalTime().TimeOfDay.ToString().Trim();

                Length.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };
                Style.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };
                RaceTime2.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };
            }

            return row;
        }

        private void SendCompetitionData(object sender, View.TouchEventArgs e, SwimmerRaceView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(NatjecanjeDetaljiActivity));
                activity2.PutExtra("id", currentItem.IdCompetition);
                activity.StartActivity(activity2);
            }
        }

        private void SendSwimmerData(object sender, View.TouchEventArgs e, SwimmerRaceView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(PlivacActivity));
                activity2.PutExtra("id", currentItem.IdSwimmer);
                activity2.PutExtra("label", currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim());
                activity2.PutExtra("gender", currentItem.Gender);
                activity2.PutExtra("dateOfBirth", currentItem.DateOfBirth.ToString("dd.MM.yyyy"));
                activity.StartActivity(activity2);
            }
        }

        public void Add(SwimmerRaceView item)
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

        public override SwimmerRaceView this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion

    }

    class UtrkaDetaljiAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}