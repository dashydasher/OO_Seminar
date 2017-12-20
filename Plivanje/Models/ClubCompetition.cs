using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class ClubCompetition : BaseEntity
    {
        public virtual int CountSwimmers { get; set; }
        public virtual Club Club { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
