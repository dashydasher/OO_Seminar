using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class CompetitionViewMap : ClassMap<CompetitionView>
    {
        public CompetitionViewMap()
        {
            Id(x => x.Id);
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Map(x => x.HallName);
            Map(x => x.Address);
            Map(x => x.PlaceName);
            Table("CompetitionView");
        }
    }
}
