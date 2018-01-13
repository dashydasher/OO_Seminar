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
            References(x => x.Club);
            References(x => x.Competition);
            Map(x => x.CountSwimmers);
            Table("ClubCompetition");
        }
    }
}
