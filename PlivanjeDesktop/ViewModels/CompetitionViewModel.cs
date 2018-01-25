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
    class CompetitionViewModel
    {
        public List<CompetitionModel> competitions { get; set; }
        public List<CompetitionModel> coachesCompetitions { get; set; }
        public List<HallModel> halls { get; set; }
        CompetitionProcessor cp = new CompetitionProcessor();
        CoachProcessor ccp = new CoachProcessor();
        ClubProcessor clp = new ClubProcessor();
        HallProcessor hp = new HallProcessor();

       

        public void LoadCompetitions()
        {
            competitions = new List<CompetitionModel>();
            
            var list = cp.GetCompetitions();
 
            foreach (var competition in list)
                competitions.Add(new CompetitionModel
                {
                    Id = competition.Id,
                    Name = competition.Name,
                    TimeStart = competition.TimeStart,
                    TimeEnd = competition.TimeEnd,
                    MyHall = competition.Hall
                });

            if (UserModel.role != null && UserModel.role.Equals("trener"))
                LoadCoachesCompetitions(UserModel.Id);
        }

        public void LoadCoachesCompetitions(int coachId)
        {
            //List<Competition> list = new List<Competition>();
            List<Competition> listMyCompetitions = new List<Competition>();       
            //list = cp.GetFutureCompetitions();
          
            coachesCompetitions = new List<CompetitionModel>();

            if (coachId != 0)
            {
                //listMyCompetitions = ccp.getMyCompetitions(coachId); --moja
                listMyCompetitions = ccp.FindMyCompetitions(coachId); //--druga natjecanja nalazi?? dodaj jos natjecanja u bazu da provjeris dal je tvoje dobro ili samo ovo
                foreach (var competition in listMyCompetitions)
                {
                   // if (listMyCompetitions.Contains(competition))
                    //{
                        coachesCompetitions.Add(new CompetitionModel
                        {
                            Id = competition.Id,
                            Name = competition.Name,
                            TimeStart = competition.TimeStart,
                            TimeEnd = competition.TimeEnd,
                            MyHall = competition.Hall
                             
                        });
                        break;
                    //}
                }
            }

        }

        public bool AddCompetition(string name, DateTime timeStart, DateTime timeEnd, Hall hall) 
        {
            Competition competition = new Competition
            {
                Name = name,
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Hall = hall
                
            };
            var cp = new CompetitionProcessor();
            try
            {
                cp.UpdateCompetition(competition);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void LoadPossibleHalls(int coachId)
        {

            int clubId = clp.getMyClubId(UserModel.Id);
            Place place = clp.getPlace(clubId);
            int placeId = place.Id;

            halls = new List<HallModel>();           
            var list = hp.getHallsInPlace(placeId);
            
            foreach (var hall in list)
                halls.Add(new HallModel
                {
                    Id = hall.Id,
                    Name = hall.Name,
                    Address = hall.Address,
                    Place = hall.Place,
                    
                });

        }




    }
}
