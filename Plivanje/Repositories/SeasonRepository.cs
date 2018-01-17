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

             Season getNowSeason(int id);
        }

    public class SeasonRepository : ISeasonRepository
    {
        public Season getNowSeason(int id)
        {
            var result = new Season();
            var klasa = new FluentNHibernateClass();
            
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Season>().Where(x => x.Id == id).List().FirstOrDefault();
                  
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
