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

            return row;
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