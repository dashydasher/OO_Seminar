using System;
using Newtonsoft.Json;

namespace PlivanjeMobile.Models
{
    public class Place
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "postalCode")]
        public int PostalCode { get; set; }
    }

    public class PlaceWrapper : Java.Lang.Object
    {
        public PlaceWrapper(Place item)
        {
            Place = item;
        }

        public Place Place { get; private set; }
    }
}