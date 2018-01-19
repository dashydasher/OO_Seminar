﻿using Plivanje.Models;
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

        public IRaceRepository Repository
        {
            get { return _RaceRepository; }
            set { _RaceRepository = value; }
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
    }
}