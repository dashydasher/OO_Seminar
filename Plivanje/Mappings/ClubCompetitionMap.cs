using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class ClubCompetitionMap : ClassMap<ClubCompetition>
    {
        public ClubCompetitionMap()
        {
            Id(x => x.Id);
            References(x => x.Club).Column("idClub").Not.LazyLoad();
            References(x => x.Competition).Column("idCompetition").Not.LazyLoad();
            Map(x => x.CountSwimmers);
            Table("ClubCompetition");
        }
    }
}
