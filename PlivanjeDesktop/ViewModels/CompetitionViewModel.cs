using Plivanje.Models;
using Plivanje.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class CompetitionViewModel
    {
        public List<Competition> competitions { get; set; }
        


        public void LoadCompetitions()
        {
            competitions = new List<Competition>();
            List<Competition> list = new List<Competition>();
            var cp = new CompetitionProcessor();
            list = cp.GetListOfCompetitions();
 
            foreach (var competition in list)
                competitions.Add(new Competition
                {
                    Name = competition.Name,
                    TimeStart = competition.TimeStart
                    
                });
        }

        
                           
    }
}
