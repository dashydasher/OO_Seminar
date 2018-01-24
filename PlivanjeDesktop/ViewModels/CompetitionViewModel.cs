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
        CompetitionProcessor cp = new CompetitionProcessor();


        public void LoadCompetitions()
        {
            competitions = new List<CompetitionModel>();
            var hp = new HallProcessor();
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
            List<Competition> list = new List<Competition>();
            List<Competition> listMyCompetitions = new List<Competition>();
            var cp = new CompetitionProcessor();
            var ccp = new CoachProcessor();
            list = cp.GetFutureCompetitions();
            listMyCompetitions = ccp.getMyCompetitions(coachId);
            competitions = new List<CompetitionModel>();

            if (coachId != 0)
            {
                
                foreach (var competition in listMyCompetitions)
                {
                    if (list.Contains(competition))
                    {
                        competitions.Add(new CompetitionModel
                        {
                            Id = competition.Id,
                            Name = competition.Name,
                            TimeStart = competition.TimeStart,
                            TimeEnd = competition.TimeEnd,
                            MyHall = competition.Hall
                             
                        });
                        break;
                    }
                }
            }
        }



    }
}
