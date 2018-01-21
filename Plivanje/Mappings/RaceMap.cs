using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class RaceMap : ClassMap<Race>
    {
        public RaceMap()
        {
            Id(x => x.Id);
            References(x => x.Pool).Column("idPool");
            References(x => x.Competition).Column("idCompetition");
            References(x => x.Length).Column("idLength");
            References(x => x.Style).Column("idStyle");
            References(x => x.Category).Column("idCategory");
            References(x => x.Refereee).Column("idReferee");
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Map(x => x.Gender);
            Table("Race");
        }
    }
}
