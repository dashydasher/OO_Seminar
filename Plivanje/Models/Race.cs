using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Race : BaseEntity
    {
        public virtual DateTime TimeStart { get; set; }
        public virtual DateTime TimeEnd { get; set; }
        public virtual string Gender { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Length Length { get; set; }
        public virtual Style Style { get; set; }
        public virtual Category Category { get; set; }
        public virtual Referee Refereee { get; set; }
    }
}
