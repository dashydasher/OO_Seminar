using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LicenceMap : ClassMap<Licence>
    {
        public LicenceMap()
        {
            Id(x => x.Id);
            Map(x => x.Number);
            Map(x => x.IssueDate);
            Table("Licence");
        }
    }
}
