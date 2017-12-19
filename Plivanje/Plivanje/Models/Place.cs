using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plivanje.Models
{
    public class Place : BaseEntity
    {
        public string Name { get; set; }
        public int PostalCode { get; set; }
    }
}