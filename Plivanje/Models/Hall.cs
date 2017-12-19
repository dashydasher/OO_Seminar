using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Hall : BaseEntity
    {
        public string Name {  get; set;}
        public string Address {get; set;}
        public Place Place { get; set; }
    }
}