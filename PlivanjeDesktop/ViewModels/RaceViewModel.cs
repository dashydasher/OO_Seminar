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
        StyleProcessor sp = new StyleProcessor();
        RefereeProcessor rfp = new RefereeProcessor();

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

        internal bool AddRace(HallModel len, StyleModel style, DateTime timeStart, DateTime timeEnd, PersonModel referee)
        {
            Race race = new Race
            {
             //   Style = sp.getStyle(style),
                TimeStart = timeStart,
                TimeEnd = timeEnd,
               // Hall = hp.getHall(hm.Id)

            };
            var rp = new RaceProcessor();
            try
            {
                rp.UpdateRace(race);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public void LoadLengths()
        {
            var lengths = new List<LengthModel>();

            var list = rp.GetLenghts();

            foreach (var len in list)
                lengths.Add(new LengthModel
                {
                    Len = len.Len                  
                });

        }

        public void LoadStyles()
        {
            var styles = new List<StyleModel>();

            var list = sp.getStyles();

            foreach (var len in list)
                styles.Add(new StyleModel
                {
                    Name = len.Name

                });

        }

        /*public void LoadReferees()
        {
            var referees = new List<PersonModel>();

            var list =  rfp.getReferees();

            foreach (var ref in list)
                referees.Add(new PersonModel
                {
                    FirstName = ref.FirstName,
                    LastName = ref.LastName

                });

        }*/



    }
}
