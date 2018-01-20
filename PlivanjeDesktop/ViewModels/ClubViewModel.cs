using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;

namespace PlivanjeDesktop.ViewModels
{
    class ClubViewModel
    {
        public List<Club> clubs { get; set; }
        public List<Club> coachesClub { get; set; }


        public void LoadClubs()
        {
            clubs = new List<Club>();
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();
            foreach (var club in list)
                clubs.Add(new Club
                {
                    Name = club.Name,
                    Address = club.Address,
                    Place = cp.getPlace(club.Id)
                });
        }

        public void LoadCoachesClub(int coachId)
        {
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();
            var season = cp.ValidSeason();
            
            if (coachId!=0)
            {
                var cr = new Plivanje.Repositories.ClubRepository();
                var coachesClubId = cr.getMyClubId(coachId, season.Id);
                coachesClub = new List<Club>();
                foreach (var club in list)
                {
                    if (club.Id.Equals(coachesClubId))
                    {
                        coachesClub.Add(new Club
                        {
                            Name = club.Name,
                            Address = club.Address,
                            Place = cp.getPlace(club.Id)
                        });
                        break;
                    }
                }
            }
        }
    }
}
