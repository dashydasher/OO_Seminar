using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class SeasonMap : ClassMap<Season>
    {
        public SeasonMap()
        {
            Id(x => x.Id);
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Table("Season");
        }
    }
}
