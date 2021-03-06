﻿using System;
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
    class Season
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "timeStart")]
        public DateTime TimeStart { get; set; }

        [JsonProperty(PropertyName = "timeEnd")]
        public DateTime TimeEnd { get; set; }
    }
}