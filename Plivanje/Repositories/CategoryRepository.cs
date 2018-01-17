using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> getCategories();
    }

    class CategoryRepository : ICategoryRepository
    {
        public List<Category> getCategories()
        {
            List<Category> result = new List<Category>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Category>)session.QueryOver<Category>().OrderBy(x => x.Id).Asc.List();

                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
