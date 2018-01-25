using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class SwimmerView : Person
    {
        public virtual string Gender { get; set; }
        public virtual string IdClub { get; set; }
        public virtual string IdSeason { get; set; }
        public virtual string IdCategory { get; set; }
        public virtual int Score { get; set; }
        public virtual DateTime TimeStart { get; set; }
        public virtual DateTime TimeEnd { get; set; }
        public virtual string Club { get; set; }
        public virtual string Category { get; set; }
        public virtual string Place { get; set; }
        public virtual string PostalCode { get; set; }
    }
}
