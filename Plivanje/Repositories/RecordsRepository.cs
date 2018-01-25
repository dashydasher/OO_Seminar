using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface IRecordsRepository
    {
        List<Record> getMenRecords();
        List<Record> getWomanRecords();
        List<Record> getAllRecords();
    }

    public class RecordsRepository : IRecordsRepository
    {
        public List<Record> getAllRecords()
        {
            List<Record> result = new List<Record>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Record>)session.QueryOver<Record>().List();

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Record> getMenRecords()
        {

            List<Record> result = new List<Record>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Record>)session.QueryOver<Record>().Where(x=>x.Gender=="M").OrderBy(x=>x.Style).Desc.List();

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Record> getWomanRecords()
        {
            List<Record> result = new List<Record>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Record>)session.QueryOver<Record>().Where(x=>x.Gender=="Ž").OrderBy(x=>x.Style).Desc.List();

                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
