using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class LicenceReferee : BaseEntity
    {
        public virtual Referee Referee { get; set; }
        public virtual Season Season { get; set; }
        public virtual Licence Licence { get; set; }
    }
}
