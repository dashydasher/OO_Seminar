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
        Category getCategory(int idCat);
    }

    public class CategoryRepository : ICategoryRepository
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

        public Category getCategory(int idCat)
        {
            Category result = new Category();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Category>().Where(x=>x.Id==idCat).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
