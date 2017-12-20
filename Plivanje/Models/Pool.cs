using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Pool : BaseEntity
    {
        public virtual int Length { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
