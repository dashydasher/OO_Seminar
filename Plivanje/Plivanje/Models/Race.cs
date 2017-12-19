using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Race : BaseEntity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Gender { get; set; }
        public Pool Pool { get; set; }
        public Competition Competition { get; set; }
        public Length Length { get; set; }
        public Style Style { get; set; }
        public Category Category { get; set; }
        public Referee Refereee { get; set; }
    }
}