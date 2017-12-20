using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class CoachSeason : BaseEntity
    {
        public virtual Club Club { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Season Season { get; set; }
    }
}
