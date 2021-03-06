﻿using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface IClubRepository
    {
        List<Club> getClubs();
        Club getClub(int id);
        List<Swimmer> getSwimmers(int id);
        void UpdateClub(Club h);
        Place getPlace(int id);
        bool validSeason(int seasonId);
        Coach getCoach(int coachId);
        Season getSeason(int id);
        CoachSeason getSeasonCoachClub(int coachId);
        int getMyClubId(int CoachId, int seasonId);
        Coach getCoachOfClub(int ClubId);
        Season ValidSeason();
        CoachSeason getSeasonCoach(int idClub, int SeasonId);
        int getMyClubId(int CoachId);
        List<Competition> GetClubCompetitions(int clubId);
        void updateClubCompetition(ClubCompetition c);
        ClubCompetition GetClubCompetition(int idClub, int idCompetition);
        List<ClubView> GetListOfClubView();
        ClubView GetClubView(int id);
        void DeleteClub(int id);
    }

    public class ClubRepository : IClubRepository
    {

        public List<Club> getClubs()
        {
            var result = new List<Club>();

            var klasa = new FluentNHibernateClass();


            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Club>)session.QueryOver<Club>().List<Club>();
                    transaction.Commit();
                }
            }
            return result;

        }

        public void UpdateClub(Club h)
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

        public Club getClub(int id)
        {
            var result = new Club();
            var klasa = new FluentNHibernateClass();
            var misto = new Place();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Club>().Where(x => x.Id == id).List().FirstOrDefault();
                    misto = session.QueryOver<Place>().Where(x => x.Id == result.Place.Id).List().FirstOrDefault();
                    result.Place = misto;
                    transaction.Commit();
                }
            }
            return result;
        }

        public Coach getCoachOfClub(int ClubId)
        {
            Club club = null;
            Season season = null;
            Coach result = new Coach();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Coach)session.QueryOver<CoachSeason>().JoinAlias(x => x.Club, () => club).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && club.Id == ClubId).Select(x => x.Coach).SingleOrDefault<Coach>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Swimmer> getSwimmers(int id)
        {
            var result = new List<Swimmer>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Swimmer>)session.QueryOver<SwimmerSeason>().Where(x =>x.Club.Id == id).Select(x => x.Swimmer).List();
                    transaction.Commit();
                }
            }
            return result;
        }

        public CoachSeason getSeasonCoach(int idClub,int SeasonId)
        {
            CoachSeason result = new CoachSeason();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                   result = (CoachSeason)session.QueryOver<CoachSeason>().Where(x => x.Club.Id ==idClub && x.Season.Id==SeasonId).List().FirstOrDefault();
  
                    transaction.Commit();
                }
            }
                        
            return result;
   
            }

        public CoachSeason getSeasonCoachClub(int coachId)
        {
            CoachSeason result = new CoachSeason();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (CoachSeason)session.QueryOver<CoachSeason>().Where(x => x.Coach.Id==coachId).List().FirstOrDefault();

                    transaction.Commit();
                }
            }

            return result;

        }
        public Season ValidSeason()
        {
            
            Season season = null;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    season = (Season)session.QueryOver<Season>().Where(x =>x.TimeEnd>DateTime.Now).SingleOrDefault();
                    
                    transaction.Commit();
                }
            }

            return season;
        }
        public int getMyClubId(int CoachId, int seasonId)
        {
            Coach coach = null;
            Season season = null;
            int result;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = session.QueryOver<CoachSeason>().Where(x => x.Coach.Id == CoachId && x.Season.Id == seasonId).Select(c => c.Club.Id).SingleOrDefault<int>();

                    result = (int)session.QueryOver<CoachSeason>().JoinAlias(x => x.Coach, () => coach).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && coach.Id == CoachId).Select(x => x.Club.Id).SingleOrDefault<int>();


                    transaction.Commit();
                }
            }

            return result;

        }
        public Coach getCoach(int coachId)
        {
            Coach result = new Coach();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Coach)session.QueryOver<Coach>().Where(x => x.Id == coachId).List().FirstOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }

        public Season getSeason(int seasonId)
        {
            Season result = new Season();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Season)session.QueryOver<Season>().Where(x => x.Id == seasonId).List().FirstOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }

        public bool validSeason(int seasonId)
        {
            bool result = false;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var r = (Season)session.QueryOver<Season>().Where(x => x.Id == seasonId && x.TimeEnd>DateTime.Now).List().FirstOrDefault();
                    if (r != null)
                    {
                        result = true;
                    }
                    transaction.Commit();
                }
            }
            return result;
        }




        public Place getPlace(int id)
        {
            var result = new Place();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Place)session.QueryOver<Place>().Where(u => u.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public int getMyClubId(int CoachId)
        {
            Coach coach = null;
            Season season = null;
            int result;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (int)session.QueryOver<CoachSeason>().JoinAlias(x => x.Coach, () => coach).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && coach.Id == CoachId).Select(x => x.Club.Id).SingleOrDefault<int>();

                    transaction.Commit();
                }
            }

            return result;

        }

        public List<Competition> GetClubCompetitions(int clubId)
        {
            Competition comp = null;
            Club club = null;
            var result= new List<Competition>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<ClubCompetition>().JoinAlias(x => x.Club, () => club).JoinAlias(x => x.Competition, () => comp).Where( () => comp.TimeStart>DateTime.Now && club.Id == clubId).Select(x=>x.Competition).List<Competition>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public void updateClubCompetition(ClubCompetition c)
        {
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(c);

                    transaction.Commit();
                }
            }
        }

        public ClubCompetition GetClubCompetition(int idClub, int idCompetition)
        {
            var result = new ClubCompetition();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<ClubCompetition>().Where(x => x.Club.Id == idClub && x.Competition.Id == idCompetition).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<ClubView> GetListOfClubView()
        {
            List<ClubView> result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<ClubView>)session.QueryOver<ClubView>().List<ClubView>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public ClubView GetClubView(int id)
        {
            var result = new ClubView();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (ClubView)session.QueryOver<ClubView>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void DeleteClub(int id)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Club r = session.QueryOver<Club>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(r);

                    transaction.Commit();
                }

            }
        }
    }
}
