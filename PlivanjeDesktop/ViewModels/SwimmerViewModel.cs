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
        SwimmerProcessor sp = new SwimmerProcessor();

        public void LoadSwimmersByClub(int clubId)
        {
            var cp = new ClubProcessor();
            var season = cp.ValidSeason();
            var list = sp.GetSwimmersInClubSeason(clubId, season.Id);
            
            Load(list);
        }

        private void Load(List<Swimmer> list)
        {

            var cp = new ClubProcessor();
            var season = cp.ValidSeason();
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

        public void LoadSwimmersByClub(string clubName)
        {

            var cp = new SwimmerProcessor();
            var list = cp.GetListOfSwimmers(clubName);
            Load(list);
        }

        public void LoadSwimmers()
        {
            var sp = new SwimmerProcessor();
            var list = sp.GetListOfSwimmers();
            Load(list);
        }

        public void LoadSwimmers(string categoryName)
        {
            var cp = new CategoryProcessor();
            var category = cp.getCategoryByName(categoryName);
            var sp = new SwimmerProcessor();
            var list = sp.GetSwimmersFromCategory(category);
            Load(list);
        }
    }

    
}
