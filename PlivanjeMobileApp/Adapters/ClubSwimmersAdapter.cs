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
    class ClubSwimmersAdapter : BaseAdapter<SwimmersView>
    {

        Activity activity;
        int layoutResourceId;
        List<SwimmersView> items = new List<SwimmersView>();

        public ClubSwimmersAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView spol;
            TextView ime;
            TextView godina;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);

                spol = row.FindViewById<TextView>(Resource.Id.spol);
                ime = row.FindViewById<TextView>(Resource.Id.naziv);
                godina = row.FindViewById<TextView>(Resource.Id.godina);
            }
            else
            {
                spol = row.FindViewById<TextView>(Resource.Id.spol);
                ime = row.FindViewById<TextView>(Resource.Id.naziv);
                godina = row.FindViewById<TextView>(Resource.Id.godina);
            }

            spol.Text = currentItem.Gender;
            ime.Text = currentItem.FirstName.Trim() + " " + currentItem.LastName;
            godina.Text = currentItem.DateOfBirth.ToString("yyyy");

            spol.Touch += delegate (object sender, View.TouchEventArgs e) { SendPlivacData(sender, e, currentItem); };
            ime.Touch += delegate (object sender, View.TouchEventArgs e) { SendPlivacData(sender, e, currentItem); };
            godina.Touch += delegate (object sender, View.TouchEventArgs e) { SendPlivacData(sender, e, currentItem); };

            return row;
        }

        private void SendPlivacData(object sender, View.TouchEventArgs e, SwimmersView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(PlivacActivity));
                activity2.PutExtra("id", currentItem.Id);
                activity2.PutExtra("label", currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim());
                activity2.PutExtra("gender", currentItem.Gender);
                activity2.PutExtra("dateOfBirth", currentItem.DateOfBirth.ToString("dd.MM.yyyy"));
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

    class ClubSwimmersAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}