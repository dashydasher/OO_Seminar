using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Plivanje.Repositories
{
    public interface IHallRepository
    {
        List<Hall> getHalls();
        Hall getHall(int id);

        Hall getHallByName(string name);
        List<Pool> getPools(int id,int len);
        Place getPlace(int id);
        void UpdateHall(Hall h);
        List<Hall> getHallsInPlace(int placeId);
        List<Pool> getPools(int idHall);
        Hall getHallCompetition(int idCompetition);
        Pool GetPool(int idPool);
    }

    public class HallRepository : IHallRepository
    {

        public List<Hall> getHalls()
        {
            var result = new List<Hall>();

            var klasa = new FluentNHibernateClass();


            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Hall>)session.QueryOver<Hall>().List<Hall>();
                    transaction.Commit();
                }
            }
            return result;

        }

        public void UpdateHall(Hall h)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(h);
                    transaction.Commit();
                }
            }
        }

        public Hall getHall(int id)
        {
            var result = new Hall();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Hall>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Hall getHallByName(string name)
        {
            var result = new Hall();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Hall>().Where(x => x.Name == name).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Pool GetPool(int PoolId)
        {
            var result = new Pool();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Pool>().Where(x => x.Id ==PoolId).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Hall getHallCompetition(int idCompetition)
        {
            var result = new Hall();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Hall)session.QueryOver<Competition>().Where(x => x.Id==idCompetition).Select(x=>x.Hall).SingleOrDefault<Hall>();
                    transaction.Commit();
                }
            }
            return result;
        }
        public List<Pool> getPools(int id,int len)
        {
            List<Pool> result = new List<Pool>();
            var klasa = new FluentNHibernateClass();
            using(var session =klasa.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    result = (List<Pool>)session.QueryOver<Pool>().Where(x => x.Hall.Id == id && x.Length==len).List<Pool>();
                    
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Pool> getPools(int idHall)
        {
            List<Pool> result = new List<Pool>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Pool>)session.QueryOver<Pool>().Where(x=>x.Hall.Id==idHall).List<Pool>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public Place getPlace(int placeId)
        {
            var message = new Place();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (Place)session.QueryOver<Place>().Where(u => u.Id== placeId).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<Hall> getHallsInPlace(int placeId)
        {
            var result = new List<Hall>();

            var klasa = new FluentNHibernateClass();


            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Hall>)session.QueryOver<Hall>().Where(x=>x.Place.Id==placeId).List<Hall>();
                    transaction.Commit();
                }
            }
            return result;
        }
    }

}
