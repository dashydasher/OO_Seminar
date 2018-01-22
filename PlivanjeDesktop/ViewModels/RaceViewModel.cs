using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class RaceViewModel
    {

        public List<RaceModel> races { get; set; }
        RaceProcessor rp = new RaceProcessor();

        public void LoadRacesByCompetition(int competitionId)
        {
            var list = rp.getRaces(competitionId);
            races = new List<RaceModel>();
            foreach (var race in list)
                races.Add(new RaceModel
                {
                    Id = race.Id,
                    Category = race.Category,
                    Gender = race.Gender,
                    Competition = race.Competition,
                    Length = race.Length,
                    Pool = race.Pool,
                    Referee = race.Refereee,
                    Style = race.Style,
                    TimeEnd = race.TimeEnd,
                    TimeStart = race.TimeStart
                });
        }
        

    }
}
