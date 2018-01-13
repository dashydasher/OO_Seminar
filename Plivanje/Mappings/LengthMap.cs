using FluentNHibernate.Mapping;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Mappings
{
    class LengthMap : ClassMap<Length>
    {
        public LengthMap()
        {
            Id(x => x.Id);
            Map(x => x.Len);
            Table("Length");
        }
    }
}
