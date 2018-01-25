using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class ClubViewMap : ClassMap<ClubView>
    {
        public ClubViewMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Address);
            Map(x => x.Place);
            Map(x => x.PostalCode);
            Table("ClubView");
        }
    }
}
