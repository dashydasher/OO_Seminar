using System;
using Newtonsoft.Json;

namespace PlivanjeMobileApp.Models
{
    class Club
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}