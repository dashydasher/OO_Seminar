using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class CoachProcessor
    {

        private ICoachRepository _CoachRepository;

        public ICoachRepository Repository
        {
            get { return _CoachRepository; }
            set { _CoachRepository = value; }
        }

        public CoachProcessor()
        {
            _CoachRepository = new CoachRepository();
        }

        public Club getMyClub(int coachId)
        {
            return _CoachRepository.getMyClub(coachId);
        }

        public List<Competition> getMyCompetitions(int coachId)
        {
            return _CoachRepository.getMyCompetitions(coachId);
        }

        public List<Coach> getCoaches()
        {
            return _CoachRepository.getCoachs();
        }

        public Coach getCoach(int id)
        {
            return _CoachRepository.getCoach(id);
        }
    }
}
