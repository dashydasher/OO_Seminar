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
        CoachSeason getSeasonCoach(int id);
        Season getSeason(int id);
        CoachSeason getSeasonCoachClub(int coachId);
        int getMyClubId(int CoachId);


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
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Club>().Where(x => x.Id == id).List().FirstOrDefault();
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

        public CoachSeason getSeasonCoach(int id)
        {
            CoachSeason result = new CoachSeason();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                   result = (CoachSeason)session.QueryOver<CoachSeason>().Where(x => x.Club.Id == id).List().FirstOrDefault();
  
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
        public int getMyClubId(int CoachId)
        {
            int result;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<CoachSeason>().Where(x => x.Coach.Id == CoachId).Select(c => c.Club.Id).SingleOrDefault<int>();

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
    }
}