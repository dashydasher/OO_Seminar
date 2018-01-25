using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{ 
    
    public interface ISeasonRepository
        {
            List<Season> getAllSeasons();
            Season getNowSeason();
        }

    public class SeasonRepository : ISeasonRepository
    {
        public List<Season> getAllSeasons()
        {
            List<Season> result = new List<Season>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Season>)session.QueryOver<Season>().List();

                    transaction.Commit();
                }
            }
            return result;
        }

        public Season getNowSeason()
        {
            var result = new Season();
            var klasa = new FluentNHibernateClass();
            
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Season>().Where(x => x.TimeEnd>DateTime.Now).List().FirstOrDefault();
                  
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
