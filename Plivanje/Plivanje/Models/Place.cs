using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public int PostalCode { get; set; }
    }
}