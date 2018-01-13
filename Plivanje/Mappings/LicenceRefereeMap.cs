using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LicenceRefereeMap : ClassMap<LicenceReferee>
    {
        public LicenceRefereeMap()
        {
            Id(x => x.Id);
            References(x => x.Referee);
            References(x => x.Season);
            References(x => x.Licence);
            Table("LicenceReferee");
        }
    }
}
