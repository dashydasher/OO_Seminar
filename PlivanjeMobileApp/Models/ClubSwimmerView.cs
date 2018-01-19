using System;
using Newtonsoft.Json;

namespace PlivanjeMobileApp.Models
{
    class ClubSwimmerView
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "idClub")]
        public string IdClub { get; set; }

        [JsonProperty(PropertyName = "idSeason")]
        public string IdSeason { get; set; }
    }
}