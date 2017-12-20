using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class SwimmerRace : BaseEntity
    {
        public virtual int Score { get; set; }
        public virtual TimeSpan RaceTime { get; set; }
        public virtual Swimmer Swimmer { get; set; }
        public virtual Race Race { get; set; }
    }
}
