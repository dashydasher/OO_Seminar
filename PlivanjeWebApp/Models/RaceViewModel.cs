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
        
        public int lenghtValue { get; set; }
        public string sytleName { get; set; }
        public string categoryName { get; set; }
        public string nameReferee { get; set; }
        public string surnameReferee { get; set; }

        public int lenghtId { get; set; }
        public int sytleId { get; set; }
        public int categoryId { get; set; }
        public int RefereeId { get; set; }
        public int poolId { get; set; }

        public DateTime datum { get; set; }
        public DateTime start { get; set; }
        public DateTime finish { get; set; }
    }
}