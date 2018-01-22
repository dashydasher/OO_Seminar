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
        bool licenceExists(int licenceNumber);

    }

    class LicenceRepository : ILicenceRepository
    {
        public bool licenceExists(int licenceNumber)
        {
            Licence result;
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Licence>().Where(x => x.Number == licenceNumber).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return (result!=null);
        }
    }
}
