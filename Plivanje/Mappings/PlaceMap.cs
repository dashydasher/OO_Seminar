using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plivanje.Mappings
{
    public class PlaceMap : ClassMap<Place>
    {
        public PlaceMap ()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PostalCode);
            Table("Place");
        }
    }
}