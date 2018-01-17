using Plivanje;
using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlivanjeWebApp.Controllers
{
    public class CompetitionController : Controller
    {
        // GET: Competition
        public ActionResult Index()
        {

            List<Competition> pom = new List<Competition>();
            List<CompetitionViewModel> competitions = new List<CompetitionViewModel>();
            

            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    pom=(List<Competition>)session.QueryOver<Competition>().List<Competition>();
                    foreach(var item in pom)
                    {
                        CompetitionViewModel c = new CompetitionViewModel();
                        c.Id = item.Id;
                        c.Name = item.Name;
                        c.HallId = item.Hall.Id;
                        c.HallName = item.Hall.Name;
                        c.TimeEnd = item.TimeEnd;
                        c.TimeStart = item.TimeStart;
                        competitions.Add(c);
                    }



                    transaction.Commit();
                }
            }

            return View(competitions);
        }

        // GET: Competition/Details/5
        public ActionResult Details(int id)
        {
            CompetitionViewModel competition = new CompetitionViewModel();
            Competition c = new Competition();
            List<RaceViewModel> racesInCOmpetition = new List<RaceViewModel>();
            List<Race> races = new List<Race>();
            CompetitionProcessor cp = new CompetitionProcessor();
           
            racesInCOmpetition = getRaces(id);
            
            try
            {
                c = cp.GetCompetition(id);
                competition.Id = c.Id;
                competition.Name = c.Name;
                competition.TimeStart = c.TimeStart;
                competition.TimeEnd = c.TimeEnd;
                competition.HallName = c.Hall.Name;

            }
            catch(Exception ex)
            {
                return View("Index");
            }

            competition.races = racesInCOmpetition;
            return View(competition);
        }

        private List<RaceViewModel> getRaces(int id)
        {
            var result = new List<Race>();
            var klasa = new FluentNHibernateClass();
            RaceViewModel race = new RaceViewModel();
            List<RaceViewModel> trke = new List<RaceViewModel>();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Race>)session.QueryOver<Race>().Where(x => x.Competition.Id == id).List<Race>();
                    if (result != null)
                    {
                        foreach (var r in result)
                        {
                            race.Id = r.Id;
                            race.Gender = r.Gender;
                            race.Category = r.Category;
                            race.Length = r.Length;
                            race.Pool = r.Pool;
                            race.Refereee = r.Refereee;
                            race.Style = r.Style;
                            race.TimeEnd = r.TimeEnd;
                            race.TimeStart = r.TimeStart;
                            race.category = r.Category.Name;
                            race.lenght = r.Length.Len;
                            race.nameReferee = r.Refereee.FirstName;
                            race.surnameReferee = r.Refereee.LastName;
                            race.sytle = r.Style.Name;
                            
                            
                            trke.Add(race);
                        }
                    }


                    transaction.Commit();
                }
            }
            return trke;
        }
        // GET: Competition/Create
        public ActionResult Create()
        {
            HallProcessor hp = new HallProcessor();
            CoachProcessor cp = new CoachProcessor();
            List<Hall> h = new List<Hall>();
            List<HallViewModel> halls = new List<HallViewModel>();
            Club c = cp.getMyClub((int)Session["UserId"]);

            h = hp.getHallsInPlace(c.Place.Id);
            foreach (var item in h)
            {
                HallViewModel pom = new HallViewModel();
                pom.Name = item.Name;
                pom.Id = item.Id;
                halls.Add(pom);
            }
            ViewBag.halls = halls;
            return View();
        }

        // POST: Competition/Create
        [HttpPost]
        public ActionResult Create(CompetitionViewModel competition)
        {
            var CompetitionProcessor = new CompetitionProcessor();
            Competition c = new Competition();
            Hall h = new Hall();
            var Hp = new HallProcessor();

            c.Name= competition.Name;
            c.TimeStart = competition.TimeStart;
            c.TimeEnd = competition.TimeEnd;
            c.Hall = Hp.getHall(competition.HallId);
            

            

            try
            {

                CompetitionProcessor.UpdateCompetition(c);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Competition/Edit/5
        public ActionResult Edit(int id)
        {
            CompetitionViewModel competition = new CompetitionViewModel();
            Competition c = new Competition();
            List<RaceViewModel> racesInCOmpetition = new List<RaceViewModel>();
            List<Race> races = new List<Race>();
            CompetitionProcessor cp = new CompetitionProcessor();
            CoachProcessor coach = new CoachProcessor();
            HallProcessor hp = new HallProcessor();
            List<HallViewModel> halls = new List<HallViewModel>();



            Club club = coach.getMyClub((int)Session["UserId"]);
            List<Hall> h = new List<Hall>();
            h = hp.getHallsInPlace(club.Place.Id);
            foreach (var item in h)
            {
                HallViewModel pom = new HallViewModel();
                pom.Name = item.Name;
                pom.Id = item.Id;
                halls.Add(pom);
            }
            ViewBag.halls = halls;

            racesInCOmpetition = getRaces(id);

            try
            {
                c = cp.GetCompetition(id);
                competition.Id = c.Id;
                competition.Name = c.Name;
                competition.TimeStart = c.TimeStart;
                competition.TimeEnd = c.TimeEnd;
                competition.HallName = c.Hall.Name;

            }
            catch (Exception ex)
            {
                return View("Index");
            }
            

            competition.races = racesInCOmpetition;
            return View(competition);
        
    }

        // POST: Competition/Edit/5
        [HttpPost]
        public ActionResult Edit(CompetitionViewModel competition)
        {
            var CompetitionProcessor = new CompetitionProcessor();
            Competition c = new Competition();
            Hall h = new Hall();
            var Hp = new HallProcessor();
            var Cp = new CompetitionProcessor();

            c = Cp.GetCompetition(competition.Id);
            c.Name = competition.Name;
            c.TimeStart = competition.TimeStart;
            c.TimeEnd = competition.TimeEnd;
            c.Hall = Hp.getHall(competition.HallId);




            try
            {

                CompetitionProcessor.UpdateCompetition(c);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Competition/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Competition/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateRace(int id)
        {
            RaceViewModel race = new RaceViewModel();
            race.Id = id;
            

            return View();
        }

        [HttpPost]
        public ActionResult DeleteRaceFromCompetition(int id, FormCollection collection)
        {
            try
            {
                RaceProcessor rp = new RaceProcessor();
                rp.deleteRace(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
