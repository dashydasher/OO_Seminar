﻿using FluentNHibernate.Mapping;
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
            References(x => x.Pool);
            References(x => x.Competition);
            References(x => x.Length);
            References(x => x.Style);
            References(x => x.Category);
            References(x => x.Refereee);
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Map(x => x.Gender);
            Table("Race");
        }
    }
}