using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{

    public interface IRaceRepository
    {
        List<Race> getRaces();
        void DeleteRace(int raceId);
        Race getRace(int id);
        void UpdateRace(Race c);
        List<Race> getRaces(int competitionId);
        
        
    }
    public class RaceRepository : IRaceRepository
    {
        public Race getRace(int id)
        {
            Race race = new Race();
            var result = new Race();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Race>().Where(x => x.Id == id).List().FirstOrDefault();
                    if(result != null)
                    {
                        race = result;
                        race.Gender = result.Gender;
                        race.Category = result.Category;
                        race.Length = result.Length;
                        race.Pool = result.Pool;
                        race.Refereee = result.Refereee;
                        race.Style = result.Style;
                        race.TimeEnd = result.TimeEnd;
                        race.TimeStart = result.TimeEnd;
                       

                    }
                    transaction.Commit();
                }
            }
            return race;
        }

        public List<Race> getRaces()
        {
            var result = new List<Race>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Race>)session.QueryOver<Race>().List<Race>();
                    
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Race> getRaces(int competitionId)
        {
            var result = new List<Race>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Race>)session.QueryOver<Race>().Where(x=>x.Competition.Id==competitionId).List<Race>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateRace(Race c)
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

        public void DeleteRace(int raceId)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Race r = session.QueryOver<Race>().Where(x => x.Id == raceId).SingleOrDefault();
                    session.Delete(r);

                    transaction.Commit();
                }

            }
        }

       
    }
}
