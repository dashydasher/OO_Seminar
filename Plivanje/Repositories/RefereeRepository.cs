using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface IRefereeRepository
    {
        List<Referee> getReferees();
        Referee getReferee(int id);
        void UpdateReferee(Referee r);
    }

    public class RefereeRepository : IRefereeRepository
    {
        public Referee getReferee(int id)
        {
            var result = new Referee();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Referee>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Referee> getReferees()
        {
            var result = new List<Referee>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Referee>)session.QueryOver<Referee>().List<Referee>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateReferee(Referee r)
        {
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(r);
                    transaction.Commit();
                }
            }
        }
    }
}
