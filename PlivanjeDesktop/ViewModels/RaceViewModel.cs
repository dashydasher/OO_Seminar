using Plivanje.Models;
using Plivanje.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class RaceViewModel
    {

        public List<Race> races { get; set; }

        public List<Race> LoadRacesByCompetition(int competitionId)
        {

            var cp = new CompetitionProcessor();
         
          //  races = cp.getRaces(competitionId);
            return races;
        }

        public void LoadRacesByCompetition(string competitionName)
        {

            var cp = new CompetitionProcessor();

           // races = cp.GetListOfRaces(competitionName);
        }




    }
}
