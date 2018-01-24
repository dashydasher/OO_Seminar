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
    class PrikazRekordiAdapter : BaseAdapter<Record>
    {
        Activity activity;
        int layoutResourceId;
        List<Record> items = new List<Record>();

        public PrikazRekordiAdapter(Activity activity, int layoutResourceId)
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
            TextView textArea5;
            TextView textArea6;
            TextView textArea7;

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
            }
            textArea1 = row.FindViewById<TextView>(Resource.Id.textArea1);
            textArea2 = row.FindViewById<TextView>(Resource.Id.textArea2);
            textArea3 = row.FindViewById<TextView>(Resource.Id.textArea3);
            textArea4 = row.FindViewById<TextView>(Resource.Id.textArea4);
            textArea5 = row.FindViewById<TextView>(Resource.Id.textArea5);
            textArea6 = row.FindViewById<TextView>(Resource.Id.textArea6);
            textArea7 = row.FindViewById<TextView>(Resource.Id.textArea7);

            textArea1.Text = currentItem.FirstName.Trim() + " " + currentItem.LastName.Trim();
            textArea2.Text = currentItem.DateOfBirth.ToString() + ", " + currentItem.Category.Trim().TrimEnd('i');
            textArea3.Text = currentItem.Style.Trim().First().ToString().ToUpper() + currentItem.Style.Trim().Substring(1);
            textArea4.Text = currentItem.Length.ToString() + "m";
            textArea5.Text = currentItem.Date.ToString("dd.MM.yyyy");
            textArea6.Text = currentItem.Place.Trim();
            textArea7.Text = "Vrijeme: " + currentItem.RaceTime.ToString("mm':'ss.fff");

            return row;
        }

        public void Add(Record item)
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

        public override Record this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion
    }
}