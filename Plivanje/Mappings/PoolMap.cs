using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class PoolMap : ClassMap<Pool>
    {
        public PoolMap()
        {
            Id(x => x.Id);
            References(x => x.Hall).Not.LazyLoad();
            Map(x => x.Length);
            Table("Pool");
        }
    }
}
