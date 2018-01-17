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
    class PlaceAdapter : BaseAdapter<Place>
    {
        Activity activity;
        int layoutResourceId;
        List<Place> items = new List<Place>();

        public PlaceAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            var currentItem = this[position];
            TextView textView;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);

                textView = row.FindViewById<TextView>(Resource.Id.mediumTextLayout);

            }
            else
            {
                textView = row.FindViewById<TextView>(Resource.Id.mediumTextLayout);
            }

            textView.Text = currentItem.Text.Trim() + " (" + currentItem.PostalCode + ")";

            return row;
        }

        public void Add(Place item)
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

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override Place this[int position]
        {
            get
            {
                return items[position];
            }
        }
        
        #endregion

    }

    class PlaceAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}