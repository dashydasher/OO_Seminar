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
    class NatjecanjaAdapter : BaseAdapter<CompetitionView>
    {

        Activity activity;
        int layoutResourceId;
        List<CompetitionView> items = new List<CompetitionView>();

        public NatjecanjaAdapter(Activity activity, int layoutResourceId)
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

            if (row == null)
            {
                var inflater = activity.LayoutInflater;
                row = inflater.Inflate(layoutResourceId, parent, false);
                textArea1 = row.FindViewById<TextView>(Resource.Id.textArea1);
                textArea2 = row.FindViewById<TextView>(Resource.Id.textArea2);
                textArea3 = row.FindViewById<TextView>(Resource.Id.textArea3);
            }
            else
            {
                textArea1 = row.FindViewById<TextView>(Resource.Id.textArea1);
                textArea2 = row.FindViewById<TextView>(Resource.Id.textArea2);
                textArea3 = row.FindViewById<TextView>(Resource.Id.textArea3);
            }

            textArea1.Text = currentItem.Name.Trim();
            textArea2.Text = currentItem.TimeStart.ToString("dd/MM/yyyy");
            textArea3.Text = currentItem.PlaceName.Trim();

            textArea1.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };
            textArea2.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };
            textArea3.Touch += delegate (object sender, View.TouchEventArgs e) { SendCompetitionData(sender, e, currentItem); };

            return row;
        }

        private void SendCompetitionData(object sender, View.TouchEventArgs e, CompetitionView currentItem)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                var activity2 = new Intent(activity, typeof(NatjecanjeDetaljiActivity));
                activity2.PutExtra("id", currentItem.Id);
                activity2.PutExtra("name", currentItem.Name.Trim());
                activity2.PutExtra("timeStart", currentItem.TimeStart.ToString("dddd dd.MM.yyyy"));
                activity2.PutExtra("timeEnd", currentItem.TimeEnd.ToString("dddd dd.MM.yyyy"));
                activity2.PutExtra("address", currentItem.Address.Trim());
                activity2.PutExtra("hallName", currentItem.HallName.Trim());
                activity2.PutExtra("placeName", currentItem.PlaceName.Trim());
                activity.StartActivity(activity2);
            }
        }

        public void Add(CompetitionView item)
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

        public override CompetitionView this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion
    }
}