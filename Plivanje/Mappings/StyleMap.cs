using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class StyleMap : ClassMap<Style>
    {
        public StyleMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Style");
        }
    }
}
