using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PlivanjeWeb.Models
{
    public class HallViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string  Place { get; set; }
        public ICollection<PoolViewModel> poolHall { get; set; }
        public int count25 { get; set;}
        public int count50 { get; set; }
    }
   
}