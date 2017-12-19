using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class SwimmerSeason : BaseEntity
    {
        public int Score { get; set; }
        public Category Category { get; set; }
        public Club Club { get; set; }
        public Swimmer Swimmer { get; set; }
        public Season Season { get; set; }
    }
}