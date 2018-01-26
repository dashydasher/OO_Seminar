using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class SwimmerResultModel
    {
        public int Id { get; set; }
        public Swimmer Swimmer { get; set; }
        public int Score { get; set; }
        public DateTime RaceTime { get; set; }
        public int IdRace { get; set; }
    }
}
