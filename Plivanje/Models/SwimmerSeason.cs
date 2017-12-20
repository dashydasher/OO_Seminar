using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class SwimmerSeason : BaseEntity
    {
        public virtual int Score { get; set; }
        public virtual Category Category { get; set; }
        public virtual Club Club { get; set; }
        public virtual Swimmer Swimmer { get; set; }
        public virtual Season Season { get; set; }
    }
}
