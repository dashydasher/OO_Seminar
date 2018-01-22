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
        }

        
                           
    }
}
