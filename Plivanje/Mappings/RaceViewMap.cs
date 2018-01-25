using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class RaceViewMap : ClassMap<RaceView>
    {
        public RaceViewMap()
        {
            Id(x => x.Id);
            Map(x => x.Style);
            Map(x => x.PoolLength);
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Map(x => x.Gender);
            Map(x => x.RaceLength);
            Map(x => x.Category);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.IdCompetition);
            Table("RaceView");
        }
    }
}
