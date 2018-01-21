using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class ClubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public Person coach { get; set; }
        public List<SwimmerViewModel> swimmers { get; set; }
    }
}