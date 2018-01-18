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
using PlivanjeMobileApp.Models;

namespace PlivanjeMobileApp.Adapters
{
    class ClubSwimmersAdapter : BaseAdapter<ClubSwimmerView>
    {

        Activity activity;
        int layoutResourceId;
        List<ClubSwimmerView> items = new List<ClubSwimmerView>();

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
                spol = row.FindViewById<TextView>(Resource.Id.largeText1);
                ime = row.FindViewById<TextView>(Resource.Id.mediumText1);
                godina = row.FindViewById<TextView>(Resource.Id.godina);
            }

            spol.Text = currentItem.Gender;
            ime.Text = currentItem.FirstName.Trim() + " " + currentItem.LastName;
            godina.Text = currentItem.DateOfBirth.ToString("yyyy");

            return row;
        }

        public void Add(ClubSwimmerView item)
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

        public override ClubSwimmerView this[int position]
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