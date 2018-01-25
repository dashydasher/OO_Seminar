using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class ClubView : BaseEntity
    {
        
        public virtual string Name { get; set; }
        
        public virtual string Address { get; set; }
        
        public virtual string Place { get; set; }
        
        public virtual string PostalCode { get; set; }
    }
}
