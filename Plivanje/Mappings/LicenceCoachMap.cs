using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LicenceCoachMap : ClassMap<LicenceCoach>
    {
        public LicenceCoachMap()
        {
            Id(x => x.Id);
            References(x => x.Coach).Column("idCoach").Not.LazyLoad();
            References(x => x.Season).Column("idSeason").Not.LazyLoad();
            References(x => x.Licence).Column("idLicence").Not.LazyLoad();
            Table("LicenceCoach");
        }
    }
}
