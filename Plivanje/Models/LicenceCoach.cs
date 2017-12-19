using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class LicenceCoach : BaseEntity
    {
        public Coach Coach { get; set; }
        public Season Season { get; set; }
        public Licence Licence { get; set; }
    }
}