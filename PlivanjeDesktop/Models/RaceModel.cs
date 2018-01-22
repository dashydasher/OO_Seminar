using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class RaceModel
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
        public Referee Referee { get; set; }
    }
}
