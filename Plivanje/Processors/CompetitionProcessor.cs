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
            return _CompetitionRepository.GetCompetitions();


        }
       

        public Competition GetCompetition(int idCompetition)
        {
            return _CompetitionRepository.getCompetition(idCompetition);
        }
        public List<Race> getRacesInCompetition(int idCompetition)
        {
            return _CompetitionRepository.getRacesInCompetition(idCompetition);
        }

        public List<Competition> GetFutureCompetitions()
        {
            return _CompetitionRepository.GetFutureCompetition();
        }

        public string ChangeNameCompetition(int id, string name)
        {
            var message = "";
            if (String.IsNullOrEmpty(name))
                message = "Potreban je naziv natjecanja..";
            else
            {
                var competition = _CompetitionRepository.getCompetition(id);
                competition.Name = name;
                _CompetitionRepository.UpdateCompetition(competition);
                message = "Podaci su uspješno spremljeni.";
            }
            return message;
        }
    }
}
