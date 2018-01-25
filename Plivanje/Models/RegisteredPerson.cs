using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public abstract class RegisteredPerson : Person
    {
        public virtual string EMail { get; set; }
        public virtual string Password { get; set; }


    }
}
