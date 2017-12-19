using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plivanje.Mappings
{
    public class HallMap : ClassMap<Hall>
    {
        public HallMap()
        {
            Id(x => x.Id);
            References(x => x.Place);
            Map(x => x.Name);
            Map(x => x.Address);
            Table("Hall");
        }
    }
}