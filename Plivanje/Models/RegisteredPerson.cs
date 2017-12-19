using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public abstract class RegisteredPerson : Person
    {
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}