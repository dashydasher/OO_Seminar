using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Place : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual int PostalCode { get; set; }
    }
}
