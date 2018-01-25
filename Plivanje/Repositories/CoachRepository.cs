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

        List<Competition> getMyCompetitions(int id);
        List<Competition> FindMyCompetitions(int coachId);
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
            Coach coach = null;
            Season season = null;
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = result = (Club)session.QueryOver<CoachSeason>().JoinAlias(x => x.Coach, () => coach).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && coach.Id == id).Select(x => x.Club).SingleOrDefault<Club>();
                    misto = session.QueryOver<Place>().Where(x => x.Id == result.Place.Id).List().FirstOrDefault();
                    result.Place = misto;

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Competition> getMyCompetitions(int id)
        {
            Club club = null;

            Club mojKlub = getMyClub(id);
            var result = new List<Competition>();
            
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //result = (List<Competition>)session.QueryOver<ClubCompetition>().JoinAlias(x => x.Club, () => club).JoinAlias(x => x.Competition, () => competition).Where(x=>x.Hall == hall && hall.Place == place && club.Place == place && mojKlub.Place == club.Place).List<Competition>();
                    result = (List<Competition>)session.QueryOver<ClubCompetition>().JoinAlias(x => x.Club, () => club).Where(() => club.Id == mojKlub.Id).Select(x=>x.Competition).List<Competition>();


                    transaction.Commit(); 
                }
            }
            return result;
        }


        public List<Competition> FindMyCompetitions(int coachId)
        {

            Club club = getMyClub(coachId);
            var result = new List<Competition>();

            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<Competition>().JoinQueryOver(x => x.Hall).Where(x => x.Place.Id == club.Place.Id).List<Competition>();

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
