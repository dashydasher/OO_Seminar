using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
    }
}