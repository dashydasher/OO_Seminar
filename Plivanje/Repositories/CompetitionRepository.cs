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
        List<Competition> GetFutureCompetition();
        List<CompetitionView> GetListOfCompetitionView();
        CompetitionView GetCompetitionView(int id);


    }
    public class CompetitionRepository : ICompetitionRepository
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
                    result = (List<Competition>)session.QueryOver<Competition>().OrderBy(x => x.TimeEnd.Date).Desc.List<Competition>();
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
                    dvorana.Name = result.Hall.Name;
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

        public List<Competition> GetFutureCompetition()
        {
            var result = new List<Competition>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<Competition>().Where(x=>x.TimeStart>DateTime.Now || (x.TimeEnd>DateTime.Now)).OrderBy(x => x.TimeStart.Date).Asc.List<Competition>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<CompetitionView> GetListOfCompetitionView()
        {
            List<CompetitionView> result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<CompetitionView>)session.QueryOver<CompetitionView>().List<CompetitionView>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public CompetitionView GetCompetitionView(int id)
        {
            var result = new CompetitionView();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (CompetitionView)session.QueryOver<CompetitionView>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}

