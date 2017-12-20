using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Club : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual Place Place { get; set; }
    }
}
