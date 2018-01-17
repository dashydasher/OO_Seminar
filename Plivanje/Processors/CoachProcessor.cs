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
    }
}
