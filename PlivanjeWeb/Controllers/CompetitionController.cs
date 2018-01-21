using Plivanje;
using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            CompetitionProcessor cp = new CompetitionProcessor();
            pom = cp.GetListOfCompetitions();

            
                    foreach(var item in pom)
                    {
                Competition comp = cp.GetCompetition(item.Id);
                        CompetitionViewModel c = new CompetitionViewModel();
                        c.Id = comp.Id;
                        c.Name = comp.Name;
                        c.HallId = comp.Hall.Id;
                        c.HallName = comp.Hall.Name;
                        c.TimeEnd = comp.TimeEnd;
                        c.TimeStart = comp.TimeStart;
                        competitions.Add(c);
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
            CompetitionProcessor cp = new CompetitionProcessor();
            RaceProcessor rp = new RaceProcessor();
            
            List<RaceViewModel> trke = new List<RaceViewModel>();

            result = cp.getRacesInCompetition(id);
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                          Race r = rp.getRace(item.Id);
                    RaceViewModel race = new RaceViewModel();
                    race.Id = r.Id;
                            race.Gender = r.Gender;
                            race.Category = r.Category;
                            race.Length = r.Length;
                            race.Pool = r.Pool;
                            race.Refereee = r.Refereee;
                            race.Style = r.Style;
                            race.TimeEnd = r.TimeEnd;
                            race.TimeStart = r.TimeStart;
                            race.categoryName = r.Category.Name;
                            race.lenghtValue = r.Length.Len;
                            race.nameReferee = r.Refereee.FirstName;
                            race.surnameReferee = r.Refereee.LastName;
                            race.sytleName = r.Style.Name;
                            
                            
                            trke.Add(race);
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
            CompetitionProcessor comp = new CompetitionProcessor();
            Session["idCompetition"] = comp.GetCompetition(id).Id;
            CategoryProcessor cp = new CategoryProcessor();
            RefereeProcessor rp = new RefereeProcessor();
            StyleProcessor sp = new StyleProcessor();
            HallProcessor hp = new HallProcessor();
            RaceProcessor racep = new RaceProcessor();

            List<Category> categories = cp.getCategories();
            List<Referee> referees = rp.getReferees();
            List<Style> styles = sp.getStyles();
            List<Length> len = racep.GetLenghts();
            List<Pool> pools = hp.getPools(hp.getHallCompetition(id).Id);

            ViewBag.pools = pools;
            ViewBag.len = len;
            ViewBag.categories = categories;
            ViewBag.styles = styles;
            ViewBag.referees = referees;

            return View();
        }
        [HttpPost]
        public ActionResult CreateRace(RaceViewModel race)
        {
            Race r = new Race();
            RaceProcessor racep = new RaceProcessor();
            CategoryProcessor cp = new CategoryProcessor();
            StyleProcessor sp = new StyleProcessor();
            RefereeProcessor rp = new RefereeProcessor();
            HallProcessor hp = new HallProcessor();
            CompetitionProcessor comp = new CompetitionProcessor();
            r.Category = cp.getCategory(race.categoryId);
            r.Style = sp.getStyle(race.sytleId);
            r.Refereee = rp.getReferee(race.RefereeId);
            r.Pool = hp.GetPool(race.poolId);
            r.Length = racep.GetLength(race.lenghtId);
            r.Gender = race.Gender;
            Debug.WriteLine(Session["idCompetition"]);
            r.Competition = comp.GetCompetition((int)Session["idCompetition"]);

            DateTime start = new DateTime(race.TimeStart.Year, race.TimeStart.Month, race.TimeStart.Day, race.start.TimeOfDay.Hours, race.start.TimeOfDay.Minutes, race.start.TimeOfDay.Seconds);
            DateTime end = new DateTime(race.TimeStart.Year, race.TimeStart.Month, race.TimeStart.Day, race.finish.TimeOfDay.Hours, race.finish.TimeOfDay.Minutes, race.finish.TimeOfDay.Seconds);
            r.TimeStart = start;
            r.TimeEnd = end;


            try
            {
                racep.UpdateRace(r);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }


        public ActionResult DeleteRaceFromCompetition(int id)
        {
            RaceProcessor rp = new RaceProcessor();

            Race r = rp.getRace(id); //spremamo trku


            if (r.TimeStart.Date == DateTime.Now.Date)
            {
                TempData["Error"] = "Nije moguće izbrisati utrku jer se odvija danas";
            }

            else
            {

                try
                {

                    rp.deleteRace(id);

                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["Error"] = "Nije moguće izbrisati utrku";
                    return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
                }
            }
            return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
        }

        public ActionResult AddSwimmersToRace(int id)
        {

            SwimmerProcessor sp = new SwimmerProcessor();

            List<Swimmer> swimmers = new List<Swimmer>();
            List<SwimmerViewModel> pom = new List<SwimmerViewModel>(); // licencirani
            swimmers = sp.SwimmersInClub((int)HttpContext.Session["clubId"]);
            foreach (var item in swimmers)
            {
                Swimmer s = sp.getSwimmer(item.Id);
                SwimmerViewModel Swimmer = new SwimmerViewModel();
                Swimmer.Id = s.Id;
                Swimmer.lastName = s.LastName;
                Swimmer.firstName = s.FirstName;
                Swimmer.dateOfBirth = s.DateOfBirth.Date;
                Swimmer.gender = s.Gender;
                if (sp.getSwimmerLicence(Swimmer.Id))
                    pom.Add(Swimmer);



            }
            return View(pom);
        }



        
    }
}
