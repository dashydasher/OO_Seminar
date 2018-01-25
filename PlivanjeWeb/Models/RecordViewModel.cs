using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class RecordViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string Style { get; set; }
        public int Length { get; set; }
        public string Place { get; set; }
        public  DateTime Date { get; set; }
        public DateTime RaceTime { get; set; }
    }
}