using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class CompetitionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string HallName { get; set; }
        public int HallId { get; set; }
        public List<RaceViewModel> races { get; set; }
        public int coachId { get; set; }
        public string status{ get; set; }
    }
}