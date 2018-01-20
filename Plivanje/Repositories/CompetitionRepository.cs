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
                    result = (List <Competition>)session.QueryOver<Competition>().List<Competition>().OrderByDescending(x => x.TimeStart);
                    transaction.Commit();
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
                    result = (List<Competition>)session.QueryOver<Competition>().OrderBy(x => x.TimeStart).Desc.List<Competition>();
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
