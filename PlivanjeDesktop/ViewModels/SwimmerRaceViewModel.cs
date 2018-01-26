using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class SwimmerRaceViewModel
    {

        public List<SwimmerRaceModel> swimmersOnRace { get; set; }
        public List<SwimmerModel> swimmers { get; set; }
        public int clubId = -1;
        public int raceId = -1;

        SwimmerProcessor sp = new SwimmerProcessor();
        RaceProcessor rp = new RaceProcessor();
        ClubProcessor cp = new ClubProcessor();

        public void LoadSwimmers(int raceId)
        {
            this.raceId = raceId;

            if (UserModel.role!=null && UserModel.role.Equals("trener"))
                LoadCoachesSwimmers();
            else
                LoadSwimmersRace();

        }

        private void LoadSwimmersRace()
        {
            var list = rp.SwimmersOnRace(raceId);
            swimmersOnRace = new List<SwimmerRaceModel>();
            foreach (var svmr in list)
                swimmersOnRace.Add(new SwimmerRaceModel
                {
                    Id = svmr.Id,
                    SwimmerId = svmr.Swimmer.Id,
                    FirstName = svmr.Swimmer.FirstName,
                    LastName = svmr.Swimmer.LastName,
                    Gender = svmr.Swimmer.Gender,
                    currentCategory = sp.GetSwimmerCategory(svmr.Swimmer),
                    currentClub = sp.getMyClub(svmr.Swimmer.Id, cp.ValidSeason().Id),
                    RaceId = raceId,
                    Score = svmr.Score
                });
        }

        private void LoadCoachesSwimmers()
        {
            
            clubId = cp.getMyClubId(UserModel.Id);

            swimmers = new List<SwimmerModel>();
            swimmersOnRace = new List<SwimmerRaceModel>();
            var swimmersRace = rp.SwimmersOnRace(raceId);
            List<int> swimmerRaceIds = new List<int>();
            foreach (var swimmer in swimmersRace)
                swimmerRaceIds.Add(swimmer.Swimmer.Id);

            var swimmersClub = sp.GetSwimmersInClubSeason(clubId, cp.ValidSeason().Id);
            foreach (var swimmer in swimmersClub)
            {
                if (swimmerRaceIds.Contains(swimmer.Id))
                    swimmersOnRace.Add(new SwimmerRaceModel
                    {
                        FirstName = swimmer.FirstName,
                        LastName = swimmer.LastName,
                        SwimmerId = swimmer.Id,
                        currentCategory = sp.GetSwimmerCategory(swimmer),
                        currentClub = cp.getClub(clubId),
                        Gender = swimmer.Gender,
                        Score = rp.GetSwimmerRace(raceId,swimmer.Id).Score,
                        RaceId = raceId
                    });
                else
                    swimmers.Add(new SwimmerModel
                    {
                        FirstName = swimmer.FirstName,
                        LastName = swimmer.LastName,
                        Id = swimmer.Id,
                        currentCategory = sp.GetSwimmerCategory(swimmer),
                        currentClub = cp.getClub(clubId),
                        DateOfBirth = swimmer.DateOfBirth,
                        Gender = swimmer.Gender
                    });
            }
        }

        public bool addSwimmerToRace(int swimmerId)
        {
            var swimmer = sp.getSwimmer(swimmerId);
            var race = rp.getRace(raceId);
            if (swimmer.Gender != race.Gender || sp.GetSwimmerCategory(swimmer).Id != race.Category.Id)
                return false;

            SwimmerRace sr = new SwimmerRace
            {
                Race = race,
                Swimmer = swimmer,
                Score = 0,
                RaceTime = DateTime.Now
            };
            rp.AddSwimmerToRace(sr);
            return true;

        }
    }
}
