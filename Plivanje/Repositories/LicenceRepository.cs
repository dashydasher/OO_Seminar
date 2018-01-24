using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface ILicenceRepository
    {
        bool CoachHasLicence(int coachId);
        bool RefereeHasLicence(int refereeId);

    }

    class LicenceRepository : ILicenceRepository
    {
        public bool CoachHasLicence(int coachId)
        {
            LicenceCoach result;
            var season = ValidSeason();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (LicenceCoach)session.QueryOver<LicenceCoach>().Where(x => x.Coach.Id == coachId && x.Season.Id == season.Id).SingleOrDefault();
                    transaction.Commit();
                }
            }
            return (result != null);
        }
                

        public bool RefereeHasLicence(int refereeId)
        {
            LicenceReferee result;
            var season = ValidSeason();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (LicenceReferee)session.QueryOver<LicenceReferee>().Where(x => x.Referee.Id == refereeId && x.Season.Id == season.Id).SingleOrDefault();
                    transaction.Commit();
                }
            }
            return (result != null);
        }

        public Season ValidSeason()
        {

            Season season = null;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    season = (Season)session.QueryOver<Season>().Where(x => x.TimeEnd > DateTime.Now).SingleOrDefault();

                    transaction.Commit();
                }
            }

            return season;
        }
    }
}
