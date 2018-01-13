using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class SwimmerSeasonMap : ClassMap<SwimmerSeason>
    {
        public SwimmerSeasonMap()
        {
            Id(x => x.Id);
            References(x => x.Category);
            References(x => x.Club);
            References(x => x.Swimmer);
            References(x => x.Season);
            Map(x => x.Score);
            Table("SwimmerSeason");
        }
    }
}
