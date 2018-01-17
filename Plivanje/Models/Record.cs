using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class Record : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string Category { get; set; }
        public virtual string Style { get; set; }
        public virtual int Length { get; set; }
        public virtual string Place { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime RaceTime { get; set; }
    }
}
