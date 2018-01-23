using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class SwimmerRaceViewModel
    {

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string RaceTime { get; set; }
        public int score { get; set; }
       
    }
}