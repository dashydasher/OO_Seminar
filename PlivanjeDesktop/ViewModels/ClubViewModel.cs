using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;

namespace PlivanjeDesktop.ViewModels
{
    class ClubViewModel
    {
        public List<ClubModel> clubs { get; set; }
        public List<ClubModel> coachesClub { get; set; }


        public void LoadClubs()
        {
            clubs = new List<ClubModel>();
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();
            foreach (var club in list)
                clubs.Add(new ClubModel
                {
                    Id = club.Id,
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
                coachesClub = new List<ClubModel>();
                foreach (var club in list)
                {
                    if (club.Id.Equals(coachesClubId))
                    {
                        coachesClub.Add(new ClubModel
                        {
                            Id = club.Id,
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

    class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Place Place { get; set; }
    }

}
