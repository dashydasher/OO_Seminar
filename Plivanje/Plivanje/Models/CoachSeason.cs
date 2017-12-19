using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class CoachSeason : BaseEntity
    {
        public Club Club { get; set; }
        public Coach Coach { get; set; }
        public Season Season { get; set; }
    }
}