using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface IStyleRepository
    {
        List<Style> getStyles();
        Style getStyle(int id);
    }
    public class StyleRepository : IStyleRepository
    {

        
            public List<Style> getStyles()
            {
                List<Style> result = new List<Style>();
                var klasa = new FluentNHibernateClass();
                using (var session = klasa.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        result = (List<Style>)session.QueryOver<Style>().OrderBy(x => x.Id).Asc.List();

                        transaction.Commit();
                    }
                }
                return result;
            }

        public Style getStyle(int id)
        {
            Style result = new Style();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Style>().Where(x => x.Id == id).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }
        }
}
