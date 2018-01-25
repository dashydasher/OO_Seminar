using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class SwimmerViewMap : ClassMap<SwimmerView>
    {
        public SwimmerViewMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.Gender);
            Map(x => x.IdClub);
            Map(x => x.IdSeason);
            Map(x => x.IdCategory);
            Map(x => x.Score);
            Map(x => x.TimeStart);
            Map(x => x.TimeEnd);
            Map(x => x.Club);
            Map(x => x.Category);
            Map(x => x.Place);
            Map(x => x.PostalCode);
            Table("SwimmersView");
        }
    }
}
