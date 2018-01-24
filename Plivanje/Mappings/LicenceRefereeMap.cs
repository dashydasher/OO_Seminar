using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LicenceRefereeMap : ClassMap<LicenceReferee>
    {
        public LicenceRefereeMap()
        {
            Id(x => x.Id);
            References(x => x.Referee).Column("idReferee").Not.LazyLoad();
            References(x => x.Season).Column("idSeason").Not.LazyLoad();
            References(x => x.Licence).Column("idLicence").Not.LazyLoad();
            Table("LicenceReferee");
        }
    }
}
