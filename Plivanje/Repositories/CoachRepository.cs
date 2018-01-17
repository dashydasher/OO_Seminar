using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface ICoachRepository
    {
        List<Coach> getCoachs();
        Coach getCoach(int id);
        void UpdateCoach(Coach c);
        Club getMyClub(int id);
    }
    class CoachRepository : ICoachRepository
    {
        public Coach getCoach(int id)
        {
            var result = new Coach();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Coach>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Coach> getCoachs()
        {
            var result = new List<Coach>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Coach>)session.QueryOver<Coach>().List<Coach>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Club getMyClub(int id)
        {
            var misto = new Place();
            var result = new Club();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Club)session.QueryOver<CoachSeason>().Where(x => x.Coach.Id == id).Select(x=>x.Club).SingleOrDefault<Club>();
                    misto = session.QueryOver<Place>().Where(x => x.Id == result.Place.Id).List().FirstOrDefault();
                    result.Place = misto;

                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateCoach(Coach c)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(c);
                    transaction.Commit();
                }
            }
        }
    }
}
