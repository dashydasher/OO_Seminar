using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class SwimmerRace : BaseEntity
    {
        public int Score { get; set; }
        public TimeSpan RaceTime { get; set; }
        public Swimmer Swimmer { get; set; }
        public Race Race { get; set; }
    }
}