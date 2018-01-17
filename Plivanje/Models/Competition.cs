using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Competition : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual DateTime TimeStart { get; set; }
        public virtual DateTime TimeEnd { get; set; }
        public virtual Hall Hall { get; set; }

    }
}
