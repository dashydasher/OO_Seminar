using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class CompetitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public Hall MyHall { get; set; }
        public string Address { get; set; }
        public Place Place { get; set; }
    }
}
