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
    }

    public class RecordsRepository : IRecordsRepository
    {



        public List<Record> getMenRecords()
        {
            List<Record> result = new List<Record>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Record>)session.QueryOver<Record>().OrderBy(x=>x.Gender).Asc.Take(18).List();

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
                    result = (List<Record>)session.QueryOver<Record>().OrderBy(x=>x.Gender).Desc.Take(17).List();

                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
