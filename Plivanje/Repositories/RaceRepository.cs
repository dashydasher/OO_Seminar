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
        Length GetLength(int id);
        List<Length> GetLenghts();
        void AddSwimmerToRace(SwimmerRace swimmerRace);
        bool isSwimmerOnRace(int idSwimmer, int idRace);
        List<SwimmerRace> SwimmersOnRace(int idRace);
        void UpdateSwimmerRace(SwimmerRace swimmerRace);
        SwimmerRace GetSwimmerRace(int idRace, int idSwimmer);
        SwimmerRace ResultIsInserted(int idRace);
        List<RaceView> getRaceViews();
        RaceView getRaceView(int id);
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
                    if (result != null)
                    {
                        race = result;
                        race.Gender = result.Gender;
                        race.Category = result.Category;
                        race.Category.Name = result.Category.Name;
                        race.Length = result.Length;
                        race.Length.Len = result.Length.Len;
                        race.Pool = result.Pool;
                        race.Pool.Length = race.Pool.Length;
                        race.Refereee = result.Refereee;
                        race.Refereee.FirstName = result.Refereee.FirstName;
                        race.Refereee.LastName = result.Refereee.LastName;

                        race.Style = result.Style;
                        race.Style.Name = result.Style.Name;
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
                    result = (List<Race>)session.QueryOver<Race>().Where(x => x.Competition.Id == competitionId).List<Race>();
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

        public List<Length> GetLenghts()
        {
            List<Length> result = new List<Length>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Length>)session.QueryOver<Length>().OrderBy(x => x.Id).Asc.List();

                    transaction.Commit();
                }
            }
            return result;
        }

        public Length GetLength(int id)
        {
            Length result = new Length();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Length>().Where(x => x.Id == id).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }
        public void AddSwimmerToRace(SwimmerRace swimmerRace)
        {

            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {


                    session.SaveOrUpdate(swimmerRace);

                    transaction.Commit();
                }
            }

        }

        public bool isSwimmerOnRace(int idSwimmer, int idRace)
        {
            var isOn = false;
            var result = new SwimmerRace();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {


                    result = session.QueryOver<SwimmerRace>().Where(x => x.Swimmer.Id == idSwimmer && x.Race.Id == idRace).SingleOrDefault();
                    if (result != null)
                    {
                        isOn = true;
                    }
                    transaction.Commit();
                }
            }
            return isOn;
        }
        public List<SwimmerRace> SwimmersOnRace(int idRace)
        {
            var result = new List<SwimmerRace>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {


                    result = (List<SwimmerRace>)session.QueryOver<SwimmerRace>().Where(x => x.Race.Id == idRace).OrderBy(x=>x.Score).Asc.List<SwimmerRace>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateSwimmerRace(SwimmerRace swimmerRace)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {


                    session.Update(swimmerRace);

                    transaction.Commit();
                }
            }
        }

        public SwimmerRace GetSwimmerRace(int idRace, int idSwimmer)
        {
            var result = new SwimmerRace();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<SwimmerRace>().Where(x => x.Swimmer.Id==idSwimmer && x.Race.Id==idRace).SingleOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public SwimmerRace ResultIsInserted(int idRace)
        {
            var result = new SwimmerRace();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<SwimmerRace>().Where(x => x.Race.Id == idRace && x.Score!=0).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<RaceView> getRaceViews()
        {
            var result = new List<RaceView>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<RaceView>)session.QueryOver<RaceView>().List<RaceView>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public RaceView getRaceView(int id)
        {
            RaceView result = new RaceView();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<RaceView>().Where(x => x.Id == id).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
