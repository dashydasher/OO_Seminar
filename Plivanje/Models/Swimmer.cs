using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Swimmer : Person
    {
        public Gender Gender { get; set; }
    }
}