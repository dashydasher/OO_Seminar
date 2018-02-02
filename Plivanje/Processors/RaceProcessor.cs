using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class RaceProcessor
    {

        private IRaceRepository _RaceRepository;
        private IUserRepository _UserRepository;

        public IRaceRepository Repository
        {
            get { return _RaceRepository; }
            set { _RaceRepository = value; }
        }

        public IUserRepository userRepository
        {
            get { return _UserRepository; }
            set { _UserRepository = value; }
        }
        public RaceProcessor()
        {
            _RaceRepository = new RaceRepository();
        }

        public List<Race> getRaces()
        {
            return _RaceRepository.getRaces();
        }

        public Race getRace(int id)
        {
            return _RaceRepository.getRace(id);
        }
        public void UpdateRace(Race race)
        {
            _RaceRepository.UpdateRace(race);
        }
        public List<Race> getRaces(int competitionId)
        {
            return _RaceRepository.getRaces(competitionId);
        }
        public void deleteRace(int raceId)
        {
            _RaceRepository.DeleteRace(raceId);
        }
       public Length GetLength(int id)
        {
            return _RaceRepository.GetLength(id);
        }
       public List<Length> GetLenghts()
        {
            return _RaceRepository.GetLenghts();
        }
        public void AddSwimmerToRace(SwimmerRace swimmerRace)
        {
            _RaceRepository.AddSwimmerToRace(swimmerRace);
        }
        public bool isSwimmerOnRace(int idSwimmer,int idRace) {
            return _RaceRepository.isSwimmerOnRace(idSwimmer, idRace);
        }
        public List<SwimmerRace> SwimmersOnRace(int idRace)
        {
            return _RaceRepository.SwimmersOnRace(idRace);
        }
        public void UpdateSwimmerRace(SwimmerRace swimmerRace)
        {
           _RaceRepository.UpdateSwimmerRace(swimmerRace);
        }
        public SwimmerRace GetSwimmerRace(int idRace, int idSwimmer)
        {
            return _RaceRepository.GetSwimmerRace(idRace, idSwimmer);
        }
        public SwimmerRace ResultIsInserted(int idRace)
        {
            return _RaceRepository.ResultIsInserted(idRace);
        }
        public void SetRaceReferee(int idReferee,int idRace)
        {
            Referee referee = new Referee();
            referee = (Referee)_UserRepository.GetRegisteredPersonFromUserId(idReferee);
            Race race = _RaceRepository.getRace(idRace);
            race.Refereee = referee;
            _RaceRepository.UpdateRace(race);


        }

        public SwimmerRace GetSwimmerRace(int idSwimmerRace)
        {
            return _RaceRepository.GetSwimmerRace(idSwimmerRace);
        }


        public Length getLength(int idLength)
        {
            return _RaceRepository.getLength(idLength);
        }

        public Style getStyle(int idStyle)
        {
            return _RaceRepository.getStyle(idStyle);
        }

        public Referee getReferee(int idReferee)
        {
            return _RaceRepository.getReferee(idReferee);
        }

        public Category getCategory(int idCategory)
        {
            return _RaceRepository.getCategory(idCategory);
        }

        public Pool getPool(int idPool)
        {
            return _RaceRepository.getPool(idPool);
        }

        public Competition getCompetition(int idCompetition)
        {
            return _RaceRepository.getCompetition(idCompetition);
        }

    }
}
