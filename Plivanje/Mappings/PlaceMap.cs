using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    public class PlaceMap : ClassMap<Place>
    {
        public PlaceMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PostalCode);
            Table("Place");
        }
    }
}
