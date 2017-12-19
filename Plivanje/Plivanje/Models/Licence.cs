using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Licence : BaseEntity
    {
        public int Number { get; set; }
        public DateTime IssueDate { get; set; }
    }
}