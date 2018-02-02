using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class PersonModel
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
    }
}
