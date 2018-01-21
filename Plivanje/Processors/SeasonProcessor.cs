using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class SeasonProcessor
    {
        private ISeasonRepository _SeasonRepository;

        public ISeasonRepository Repository
        {
            get { return _SeasonRepository; }
            set { _SeasonRepository = value; }
        }

        public SeasonProcessor()
        {
            _SeasonRepository = new SeasonRepository();
        }
        public Season getNowSeason()
        {
            return _SeasonRepository.getNowSeason();
        }

    }
}
