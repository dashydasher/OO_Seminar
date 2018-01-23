﻿using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class SwimmerProcessor
    {
        private ISwimmerRepository _swimmerRepository;

        public ISwimmerRepository Repository
        {
            get { return _swimmerRepository; }
            set { _swimmerRepository = value; }
        }

        public SwimmerProcessor()
        {
            _swimmerRepository = new SwimmerRepository();
        }

        public List<Swimmer> GetListOfSwimmers()
        {
            return Repository.GetListOfSwimmers();
        }

        public Swimmer getSwimmer(int id)
        {
            return _swimmerRepository.GetSwimmer(id);
        }
        public void UpdateSwimer(Swimmer swimmer)
        {
            _swimmerRepository.UpdateSwimmer(swimmer);
        }
        public void StoreSwimmerChanges(Swimmer swimmer)
        {
            _swimmerRepository.StoreSwimmerChanges(swimmer);
        }
       public bool getSwimmerLicence(int idSwimmer)
        {
            return _swimmerRepository.getSwimmerLicence(idSwimmer);
        }

        public List<Swimmer> SwimmersInClub(int clubId)
        {
            return _swimmerRepository.SwimmersInClub(clubId);
        }

        public void UpdateSwimmerLicence(Swimmer swimmer)
        {
            _swimmerRepository.UpdateSwimmerLicence(swimmer);
        }
        public List<Swimmer> GetListOfSwimmers(string club)
        {
            return _swimmerRepository.GetListOfSwimmers(club);
        }
        public bool IsSwimmerFree(int swimmerId)
        {
            return _swimmerRepository.IsSwimmerFree(swimmerId);
        }
        public void UpdateSwimmerSeason(SwimmerSeason swimmerSeason)
        {
            _swimmerRepository.UpdateSwimmerSeason(swimmerSeason);
        }

        public Category GetSwimmerCategory(Swimmer swimmer)
        {
            return _swimmerRepository.GetSwimmerCategory(swimmer);
        }

      

        public SwimmerSeason GetSwimmerSeason(int swimmerId)
        {
            return _swimmerRepository.GetSwimmerSeason(swimmerId);
        }
        public void deleteSwimmerFromClub(SwimmerSeason swSeason)
        {
            _swimmerRepository.deleteSwimmerFromClub(swSeason);
        }

        public Club getMyClub(int swimmerId, int seasonId)
        {
            return _swimmerRepository.GetMyClub(swimmerId, seasonId);
        }
       public List<Swimmer> GetSwimmersInClubSeason(int clubId, int seasonId)
        {
            return _swimmerRepository.GetSwimmersInClubSeason(clubId, seasonId);
        }

       public List<Swimmer> GetSwimmersByCategory(string category)
        {
            return _swimmerRepository.GetSwimmersByCategory(category);
        }
       public List<Swimmer> GetSwimmersByCategoryAndClub(string category, string club)
        {
            return _swimmerRepository.GetSwimmersByCategoryAndClub(category, club);
        }

        public List<SwimmerSeason> GetSwimmerSeasons(int swimmerId)
        {
            return _swimmerRepository.GetSwimmerSeasons(swimmerId);
        }
        public List<SwimmerRace> GetSwimmerRaces(int swimmerId)
        {
            return _swimmerRepository.GetSwimmerRaces(swimmerId);
        }

        public List<Swimmer> GetSwimmersFromCategory(Category category)
        {
            return _swimmerRepository.GetSwimmersFromCategory(category);
        }

     
    }
}