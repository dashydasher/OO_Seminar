using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    public class HallMap : ClassMap<Hall>
    {
        public HallMap()
        {
            Id(x => x.Id);
            References(x => x.Place).Not.LazyLoad();
            Map(x => x.Name);
            Map(x => x.Address);
            Table("Hall");
        }
    }
}
