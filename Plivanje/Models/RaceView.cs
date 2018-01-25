using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class RaceView : BaseEntity
    {
        public virtual string Style { get; set; }
        public virtual int PoolLength { get; set; }
        public virtual DateTime TimeStart { get; set; }
        public virtual DateTime TimeEnd { get; set; }
        public virtual string Gender { get; set; }
        public virtual int RaceLength { get; set; }
        public virtual string Category { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string IdCompetition { get; set; }
    }
}
