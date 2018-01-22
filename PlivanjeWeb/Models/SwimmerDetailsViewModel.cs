using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class SwimmerDetailsViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<SwimmerSeason> seasons { get; set; }
        public List<SwimmerRace> races { get; set; }
    }
}