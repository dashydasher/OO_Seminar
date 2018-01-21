using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{

    public interface ICompetitionRepository
    {
        void UpdateCompetition(Competition c);
        List<Competition> GetListOfCompetitions();

        List<Competition> GetCompetitions();

        Competition getCompetition(int idCompetition);
        List<Race> getRacesInCompetition(int idCompetition);



    }
    class CompetitionRepository : ICompetitionRepository
    {
        public void UpdateCompetition(Competition c)
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

        public List<Competition> GetListOfCompetitions()
        {
            var result = new List<Competition>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<Competition>().List<Competition>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Competition getCompetition(int idCompetition)
        {
            var result = new Competition();
            var clas = new FluentNHibernateClass();
            var dvorana = new Hall();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Competition>().Where(x => x.Id == idCompetition).SingleOrDefault();
                    dvorana = result.Hall;
                    dvorana.Name = result.Name;
                    result.Hall = dvorana;
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Race> getRacesInCompetition(int idCompetition)
        {
            var result = new List<Race>();
            var klasa = new FluentNHibernateClass();

            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Race>)session.QueryOver<Race>().Where(x => x.Competition.Id == idCompetition).List<Race>();

                }
            }
            return result;
        }

        public List<Competition> GetCompetitions()
        {
            var result = new List<Competition>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<Competition>().List<Competition>();
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}

