using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class RaceEditViewModel
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Gender Gender { get; set; }
        public Pool Pool { get; set; }
        public Competition Competition { get; set; }
        public Length Length { get; set; }
        public Style Style { get; set; }
        public Category Category { get; set; }
        public Referee Refereee { get; set; }
        public List<SwimmerRace> swimmers { get; set; }
        
   
        public DateTime datum { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
    }
}