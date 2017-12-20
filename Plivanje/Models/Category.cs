using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual int AgeFrom { get; set; }
        public virtual int AgeTo { get; set; }
    }
}
