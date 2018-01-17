using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWebApp.Models
{
    public class RaceViewModel
    {
        public int Id { get; set; }
        public  DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Gender Gender { get; set; }
        public  Pool Pool { get; set; }
        public  Competition Competition { get; set; }
        public  Length Length { get; set; }
        public Style Style { get; set; }
        public Category Category { get; set; }
        public  Referee Refereee { get; set; }
        
        public int lenght { get; set; }
        public string sytle { get; set; }
        public string category { get; set; }
        public string nameReferee { get; set; }
        public string surnameReferee { get; set; }
    }
}