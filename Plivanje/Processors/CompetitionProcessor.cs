using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class CompetitionProcessor
    {
        private ICompetitionRepository _CompetitionRepository;

        public ICompetitionRepository Repository
        {
            get { return _CompetitionRepository; }
            set { _CompetitionRepository = value; }
        }

        public CompetitionProcessor()
        {
            _CompetitionRepository = new CompetitionRepository();
        }

        public void UpdateCompetition(Competition c)
        {
            _CompetitionRepository.UpdateCompetition(c);
        }

        public List<Competition> GetListOfCompetitions()
        {
            return Repository.GetListOfCompetitions();
        }


        public List<Competition> GetCompetitions()
        {
            return Repository.GetCompetitions();


        }
       

        public Competition GetCompetition(int idCompetition)
        {
            return Repository.getCompetition(idCompetition);
        }
        public List<Race> getRacesInCompetition(int idCompetition)
        {
            return Repository.getRacesInCompetition(idCompetition);
        }
    }
}
