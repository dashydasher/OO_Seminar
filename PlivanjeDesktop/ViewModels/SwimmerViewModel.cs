using System;
using System.Collections.Generic;
using System.Linq;
using Plivanje.Models;
using Plivanje.Processors;
using System.Text;
using System.Threading.Tasks;
using PlivanjeDesktop.Models;

namespace PlivanjeDesktop.ViewModels
{
    class SwimmerViewModel
    {
        public List<SwimmerModel> swimmers { get; set; }
        public List<SwimmerModel> swimmersCoach { get; set; }
        public int clubId = -1;
        SwimmerProcessor sp = new SwimmerProcessor();

        public void LoadSwimmersByClub(int clubId)
        {
            this.clubId = clubId;
            var cp = new ClubProcessor();
            var season = cp.ValidSeason();
            var list = sp.GetSwimmersInClubSeason(clubId, season.Id);
            if (UserModel.role.Equals("trener"))
            {
                Load(list, false);
                LoadSwimmersWithoutClub();
            }
            else
                Load(list, true);
        }
        

        public void LoadSwimmers()
        {
            var list = sp.GetListOfSwimmers();
            Load(list, true);
        }

        public void LoadSwimmers(string categoryName)
        {
            var cp = new CategoryProcessor();
            var category = cp.getCategoryByName(categoryName);
            var sp = new SwimmerProcessor();
            var list = sp.GetSwimmersFromCategory(category);
            Load(list, true);
        }

        internal void LoadSwimmersWithoutClub()
        {
            var sp = new SwimmerProcessor();
            var list = sp.GetListOfSwimmers();
            swimmers = new List<SwimmerModel>();
            foreach (var swimmer in list)
                if (sp.IsSwimmerFree(swimmer.Id))
                    swimmers.Add(new SwimmerModel
                    {
                        Id = swimmer.Id,
                        FirstName = swimmer.FirstName,
                        LastName = swimmer.LastName,
                        DateOfBirth = swimmer.DateOfBirth,
                        Gender = swimmer.Gender,
                        currentClub = null,
                        currentCategory = sp.GetSwimmerCategory(swimmer)
                    });
        }

        private void Load(List<Swimmer> list, bool regularSwimmers)
        {

            var cp = new ClubProcessor();
            var season = cp.ValidSeason();
            if (regularSwimmers)
            {
                swimmers = new List<SwimmerModel>();
                foreach (var swimmer in list)
                {
                    swimmers.Add(new SwimmerModel
                    {
                        Id = swimmer.Id,
                        FirstName = swimmer.FirstName,
                        LastName = swimmer.LastName,
                        DateOfBirth = swimmer.DateOfBirth,
                        Gender = swimmer.Gender,
                        currentClub = sp.getMyClub(swimmer.Id, season.Id),
                        currentCategory = sp.GetSwimmerCategory(swimmer)
                    });
                }
            }
            else
            {
                swimmersCoach = new List<SwimmerModel>();
                foreach (var swimmer in list)
                {
                    swimmersCoach.Add(new SwimmerModel
                    {
                        Id = swimmer.Id,
                        FirstName = swimmer.FirstName,
                        LastName = swimmer.LastName,
                        DateOfBirth = swimmer.DateOfBirth,
                        Gender = swimmer.Gender,
                        currentClub = sp.getMyClub(swimmer.Id, season.Id),
                        currentCategory = sp.GetSwimmerCategory(swimmer)
                    });
                }
            }
        }
        public bool AddSwimmerToClub(SwimmerModel swimmer)
        {
            bool success = true;
            var cp = new ClubProcessor();
            var sw = new Swimmer
            {
                DateOfBirth = swimmer.DateOfBirth
            };
            SwimmerSeason ss = new SwimmerSeason
            {
                Score = 0,
                Category = sp.GetSwimmerCategory(sw),
                Club = cp.getClub(clubId),
                Swimmer = sp.getSwimmer(swimmer.Id),
                Season = cp.ValidSeason()
            };
            try
            {
                sp.UpdateSwimmerSeason(ss);
            }
            catch (Exception e)
            {
                success = false;
            }
            return success;

        }
        public bool DeleteSwimmerFromClub(SwimmerModel selectedSwimmer)
        {
            bool success = true;
            SwimmerSeason ss = sp.GetSwimmerSeason(selectedSwimmer.Id);
            try
            {
                sp.deleteSwimmerFromClub(ss);
            }
            catch (Exception e)
            {
                success = false;
            }
            return success;
        }
    }

    
}
