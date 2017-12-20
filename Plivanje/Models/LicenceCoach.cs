using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class LicenceCoach : BaseEntity
    {
        public virtual Coach Coach { get; set; }
        public virtual Season Season { get; set; }
        public virtual Licence Licence { get; set; }
    }
}
