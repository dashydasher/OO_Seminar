using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class StyleProcessor
    {
        private IStyleRepository _StyleRepository;

        public IStyleRepository Repository
        {
            get { return _StyleRepository; }
            set { _StyleRepository = value; }
        }

        public StyleProcessor()
        {
            _StyleRepository = new StyleRepository();
        }

        public List<Style> getStyles()
        {
            return Repository.getStyles();
        }
        public Style getStyle(int id)
        {
            return _StyleRepository.getStyle(id);
        }
    }
}
