using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class HallModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Place Place { get; set; }
    }
}
