﻿using FluentNHibernate.Mapping;
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
            References(x => x.Category).Column("idCategory");
            References(x => x.Club).Column("idClub");
            References(x => x.Swimmer).Column("idSwimmer");
            References(x => x.Season).Column("idSeason");
            Map(x => x.Score);
            Table("SwimmerSeason");
        }
    }
}
