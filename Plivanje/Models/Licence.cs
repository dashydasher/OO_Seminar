using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Licence : BaseEntity
    {
        public virtual int Number { get; set; }
        public virtual DateTime IssueDate { get; set; }
    }
}
