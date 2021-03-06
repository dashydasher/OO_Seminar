﻿using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class CoachSeasonMap : ClassMap<CoachSeason>
    {
        public CoachSeasonMap()
        {
            Id(x => x.Id);
            References(x => x.Club).Column("idClub").Not.LazyLoad();
            References(x => x.Coach).Column("idCoach").Not.LazyLoad();
            References(x => x.Season).Column("idSeason").Not.LazyLoad();
            Table("CoachSeason");
        }
    }
}
