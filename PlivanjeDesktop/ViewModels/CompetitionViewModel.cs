﻿using Plivanje.Models;
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

        public CompetitionModel competition { get; set; }

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
            {
                LoadCoachesCompetitions(UserModel.Id);
                LoadPossibleHalls(UserModel.Id);
            }
        }

        public void LoadCoachesCompetitions(int coachId)
        {
        
            List<Competition> listMyCompetitions = new List<Competition>();
        
            coachesCompetitions = new List<CompetitionModel>();

            if (coachId != 0)
            {
             
                listMyCompetitions = ccp.FindMyCompetitions(coachId);
                foreach (var competition in listMyCompetitions)
                {
                   
                    coachesCompetitions.Add(new CompetitionModel
                    {
                        Id = competition.Id,
                        Name = competition.Name,
                        TimeStart = competition.TimeStart,
                        TimeEnd = competition.TimeEnd,
                        MyHall = competition.Hall

                    });
                    
                }
            }

        }

        public bool AddCompetition(string name, DateTime timeStart, DateTime timeEnd, HallModel hm) 
        {
            Competition competition = new Competition
            {
                Name = name,
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Hall = hp.getHall(hm.Id)
                
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

            int clubId = clp.getMyClubId(coachId);
            var club = clp.getClub(clubId);

            halls = new List<HallModel>();           
            var list = hp.getHallsInPlace(club.Place.Id);
            
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
