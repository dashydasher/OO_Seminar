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

        public UtrkaDetaljiAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView RaceTime;
            TextView Swimmer;
            TextView Score;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                RaceTime = row.FindViewById<TextView>(Resource.Id.textArea1);
                Swimmer = row.FindViewById<TextView>(Resource.Id.textArea2);
                Score = row.FindViewById<TextView>(Resource.Id.textArea3);
            }
            else
            {
                RaceTime = row.FindViewById<TextView>(Resource.Id.textArea1);
                Swimmer = row.FindViewById<TextView>(Resource.Id.textArea2);
                Score = row.FindViewById<TextView>(Resource.Id.textArea3);
            }
            RaceTime.Text = currentItem.RaceTime.ToUniversalTime().TimeOfDay.ToString().Trim();
            Swimmer.Text = currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim();
            Score.Text = "bod: " + currentItem.Score;

            RaceTime.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };
            Swimmer.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };
            Score.Touch += delegate (object sender, View.TouchEventArgs e) { SendSwimmerData(sender, e, currentItem); };

            return row;
        }

        private void SendSwimmerData(object sender, View.TouchEventArgs e, SwimmerRaceView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Down)
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