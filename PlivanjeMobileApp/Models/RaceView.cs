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
using Newtonsoft.Json;

namespace PlivanjeMobileApp.Models
{
    class RaceView
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "style")]
        public string Style { get; set; }

        [JsonProperty(PropertyName = "poolLength")]
        public int PoolLength { get; set; }

        [JsonProperty(PropertyName = "timeStart")]
        public DateTime TimeStart { get; set; }

        [JsonProperty(PropertyName = "timeEnd")]
        public DateTime TimeEnd { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "raceLength")]
        public int RaceLength { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "idCompetition")]
        public string IdCompetition { get; set; }
    }
}