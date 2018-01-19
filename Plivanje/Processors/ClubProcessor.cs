using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class ClubProcessor
    {
        private IClubRepository _ClubRepository;

        public IClubRepository Repository
        {
            get { return _ClubRepository; }
            set { _ClubRepository = value; }
        }

        public ClubProcessor()
        {
            _ClubRepository = new ClubRepository();
        }

        public List<Club> getClubs()
        {
            return _ClubRepository.getClubs();
        }

        public Club getClub(int id)
        {
            return _ClubRepository.getClub(id);
        }


       public List<Swimmer> getSwimmers(int id)
        {
            return _ClubRepository.getSwimmers(id);
        }


        public void UpdateClub(Club h)
        {
            _ClubRepository.UpdateClub(h);
        }
        public Place getPlace(int id)
        {
            return _ClubRepository.getPlace(id);
        }

        public bool validSeason(int seasonId)
        {
            return _ClubRepository.validSeason(seasonId);
        }
        public Coach getCoach(int coachId)
        {
            return _ClubRepository.getCoach(coachId);
        }
        public CoachSeason getSeasonCoach(int idClub,int idSeason)
        {
            return _ClubRepository.getSeasonCoach(idClub,idSeason);
        }

        public Season getSeason(int id)
        {
            return _ClubRepository.getSeason(id);
        }
        public CoachSeason getSeasonCoachClub(int coachId)
        {
            return _ClubRepository.getSeasonCoachClub(coachId);
        }
        public int getMyClubId(int CoachId)
        {
            return _ClubRepository.getMyClubId(CoachId);
        }
        public Coach getCoachOfClub(int ClubId)
        {
            return _ClubRepository.getCoachOfClub(ClubId);
        }
        public Season ValidSeason()
        {
            return _ClubRepository.ValidSeason();
        }

    }
}
