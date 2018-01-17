using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    class CategoryProcessor
    {
        private ICategoryRepository _categoryRepository;

        public ICategoryRepository Repository
        {
            get { return _categoryRepository; }
            set { _categoryRepository = value; }
        }

        public CategoryProcessor()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<Category> getCategories()
        {
            return Repository.getCategories();
        }
    }
}
