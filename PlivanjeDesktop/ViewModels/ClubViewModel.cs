using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;

namespace PlivanjeDesktop.ViewModels
{
    class ClubViewModel
    {
        public List<Club> clubs { get; set; }
        public Club coachesClub { get; set; }

        public void LoadClubs(int coachId)
        {
            clubs = new List<Club>();
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();
            foreach (var club in list)
                clubs.Add(club);
            //foreach (var club in list)
            //    clubs.Add(new Club { Name = club.Name,
            //        Address = club.Address,
            //        Place = cp.getPlace(club.Id)
            //    });
            if (coachId!=0)
            {
                var cr = new Plivanje.Repositories.ClubRepository();
                var coachesClubId = cr.getMyClubId(coachId);
                foreach (var club in list)
                {
                    if (club.Id.Equals(coachesClubId))
                    {
                        coachesClub = club;
                        break;
                    }
                }
            }
        }
        //public Club getClub(int coachId)
        //{
        //    var cr = new Plivanje.Repositories.ClubRepository();
        //    var coachesClubId = cr.getMyClubId(coachId);
            
        //    var cp = new ClubProcessor();
        //    List<Club> list = cp.getClubs();
        //    Club coachesClub = new Club();
        //    foreach (var club in clubs)
        //        if (club.Id.Equals(coachesClubId))
        //            coachesClub = club;
        //    return coachesClub;
        //}
    }
}
