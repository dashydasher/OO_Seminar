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
        public List<StyleModel> styles { get; set; }
        public List<LengthModel> lengths { get; set; }
        public List<PersonModel> referees { get; set; }
        public List<CategoryModel> categories { get; set; }
        public List<PoolModel> pools { get; set; }
        public bool isMyCompetition = false;

        RaceProcessor rp = new RaceProcessor();
        StyleProcessor sp = new StyleProcessor();
        RefereeProcessor rfp = new RefereeProcessor();
        CategoryProcessor cp = new CategoryProcessor();

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

            if (UserModel.role != null && UserModel.role.Equals("trener"))
            {
                LoadRest(competitionId);
            }
        }


        internal bool AddRace(string gender, int idLen, int idStyle, DateTime timeStart, DateTime timeEnd, int idReferee, int idCompetition, int idPool, int idCategory)
        {
            Race race = new Race
            {
                Gender = gender.Equals("M")?Gender.M:Gender.Ž,
                Length = rp.getLength(idLen),
                Style = rp.getStyle(idStyle),
                TimeStart = timeStart,
                TimeEnd = timeEnd,
                Refereee = rp.getReferee(idReferee),
                Competition = rp.getCompetition(idCompetition),
                Pool = rp.getPool(idPool),
                Category = rp.getCategory(idCategory)
            };
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


        private void LoadRest(int competitionId)
        {
            LoadLengths();
            LoadStyles();
            LoadReferees();
            LoadCategories();
            LoadPools(competitionId);

            var cp = new CoachProcessor();
            var competitions = cp.FindMyCompetitions(UserModel.Id);
            foreach (var comp in competitions)
                if (comp.Id == competitionId)
                {
                    isMyCompetition = true;
                    break;
                }
        }

        private void LoadLengths()
        {
            lengths = new List<LengthModel>();

            var list = rp.GetLenghts();

            foreach (var len in list)
                lengths.Add(new LengthModel
                {
                    Id = len.Id,
                    Len = len.Len                  
                });

        }

        private void LoadStyles()
        {
            styles = new List<StyleModel>();

            var list = sp.getStyles();

            foreach (var style in list)
                styles.Add(new StyleModel
                {
                    Id = style.Id,
                    Name = style.Name

                });

        }

        private void LoadCategories()
        {
            categories = new List<CategoryModel>();

            var list = cp.getCategories();

            foreach (var category in list)
                categories.Add(new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name

                });
        }

        private void LoadPools(int idCompetition)
        {
            pools = new List<PoolModel>();
            var hp = new HallProcessor();
            var hall = hp.getHallCompetition(idCompetition);
            var list = hp.getPools(hall.Id);

            foreach (var pool in list)
                pools.Add(new PoolModel
                {
                    Id = pool.Id,
                    Name = pool.Length + "m " + hall.Name
                });
        }

        private void LoadReferees()
        {
            referees = new List<PersonModel>();

            var list =  rfp.getReferees();

            foreach (var referee in list)
                referees.Add(new PersonModel
                {
                    Id = referee.Id,
                    Name = referee.FirstName.Trim() + " " + referee.LastName.Trim()
                });

        }



    }
}
