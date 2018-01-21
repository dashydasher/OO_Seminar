using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LicenceSwimmerMap : ClassMap<LicenceSwimmer>
    {
        public LicenceSwimmerMap()
        {
            Id(x => x.Id);
            References(x => x.Swimmer).Not.LazyLoad();
            References(x => x.Season).Not.LazyLoad();
            References(x => x.Licence).Not.LazyLoad();
            Table("LicenceSwimmer");
        }
    }
}
