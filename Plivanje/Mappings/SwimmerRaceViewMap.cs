using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class SwimmerRaceViewMap : ClassMap<SwimmerRaceView>
    {
        public SwimmerRaceViewMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.Gender);
            Map(x => x.Score);
            Map(x => x.Length);
            Map(x => x.Style);
            Map(x => x.RaceTime).CustomType<NHibernate.Type.TimeType>();
            Map(x => x.Time);
            Map(x => x.IdRace);
            Map(x => x.IdSwimmer);
            Map(x => x.IdCompetition);
            Table("SwimmerRaceView");
        }
    }
}
