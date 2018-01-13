﻿using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class SwimmerRaceMap : ClassMap<SwimmerRace>
    {
        public SwimmerRaceMap()
        {
            Id(x => x.Id);
            References(x => x.Swimmer);
            References(x => x.Race);
            Map(x => x.Score);
            Map(x => x.RaceTime);
            Table("SwimmerRace");
        }
    }
}
