using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class RecordMap : ClassMap<Record>
    {
        public RecordMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.DateOfBirth);
            Map(x => x.Gender);
            Map(x => x.Category);
            Map(x => x.Style);
            Map(x => x.Length);
            Map(x => x.Place);
            Map(x => x.Date);
            Map(x => x.RaceTime);
            Table("Record");
        }
    }
}
