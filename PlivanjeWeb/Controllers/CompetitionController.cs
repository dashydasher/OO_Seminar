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


            foreach (var item in pom)
            {
                Competition comp = cp.GetCompetition(item.Id);
                CompetitionViewModel c = new CompetitionViewModel();
                c.Id = comp.Id;
                c.Name = comp.Name;
                c.HallId = comp.Hall.Id;
                c.HallName = comp.Hall.Name;
                c.TimeEnd = comp.TimeEnd;
                c.TimeStart = comp.TimeStart;
                if (c.TimeEnd < DateTime.Now)
                {
                    c.status = "Održano";
                }
                else if(c.TimeStart>DateTime.Now)
                {
                    c.status = "To be..";
                }
                else
                {
                    c.status = "U tijeku..";
                }
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
            Session["idCompetition"] = id;

            racesInCOmpetition = getRaces(id);

            try
            {
                c = cp.GetCompetition(id);
                competition.Id = c.Id;
                competition.Name = c.Name;
                competition.TimeStart = c.TimeStart;
                competition.TimeEnd = c.TimeEnd;
                competition.HallName = c.Hall.Name;
                if (c.TimeEnd < DateTime.Now)
                {
                    competition.status = "Održano";
                }
                else if (c.TimeStart > DateTime.Now)
                {
                    competition.status = "To be..";
                }
                else
                {
                    competition.status = "U tijeku..";
                }

            }
            catch (Exception ex)
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
            List<SwimmerRace> pom = new List<SwimmerRace>();
           

            result = cp.getRacesInCompetition(id);
            if (result != null)
            {
                foreach (var item in result)
                {
                    List<SwimmerViewModel> plivaci = new List<SwimmerViewModel>();
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
                    pom = rp.SwimmersOnRace(item.Id);
                    foreach(var p in pom)
                    {
                        SwimmerViewModel swimmer = new SwimmerViewModel();
                        swimmer.Id = p.Id;
                        swimmer.lastName = p.Swimmer.LastName;
                        swimmer.firstName = p.Swimmer.FirstName;
                        swimmer.dateOfBirth = p.Swimmer.DateOfBirth;
                        swimmer.rezultat = p.RaceTime.TimeOfDay;
                        plivaci.Add(swimmer);

                    }

                    race.swimmers = plivaci;
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
            if (comp.GetCompetition(id).TimeEnd < DateTime.Now)
            {
                TempData["Error"] = "Natjecanje je završeno, utrku više nije moguće dodati";
                return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
            }
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


            if (r.TimeStart.Date < DateTime.Now.Date)
            {
                TempData["Error"] = "Nije moguće izbrisati utrku, utrka se odvija danas ili se već odvila";
                return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
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
            
        }

        public ActionResult AddSwimmersToRace(int id)
        {
            var comp = new CompetitionProcessor();
            if (comp.GetCompetition((int)Session["idCompetition"]).TimeEnd < DateTime.Now)
            {
                TempData["Error"] = "Trka je završila, plivače više nije moguće prijaviti";
                return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
            }
            SwimmerProcessor sp = new SwimmerProcessor();

            List<Swimmer> swimmers = new List<Swimmer>();
            List<SwimmerViewModel> pom = new List<SwimmerViewModel>(); // licencirani
            swimmers = sp.SwimmersInClub((int)HttpContext.Session["clubId"]);
            Session["idRace"] = id;
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
        public ActionResult AddSwimmerToRace(int idSwimmer)
        {
            RaceProcessor rp = new RaceProcessor();
            SwimmerProcessor sp = new SwimmerProcessor();
            CategoryProcessor cp = new CategoryProcessor();
            Race race = rp.getRace((int)Session["idRace"]);
            Swimmer swimmer = sp.getSwimmer(idSwimmer);
            Category cat1 = sp.GetSwimmerCategory(swimmer);
            Category cat2 = cp.getCategory(race.Category.Id);
            if (cat1.Id == cat2.Id && !rp.isSwimmerOnRace(swimmer.Id,race.Id) && race.Gender==swimmer.Gender)
            {
                try
                {
                    SwimmerRace swimmerRace = new SwimmerRace(); ;
                    swimmerRace.Swimmer = swimmer;
                    swimmerRace.Race = race;
                    swimmerRace.RaceTime = DateTime.Now;
                    rp.AddSwimmerToRace(swimmerRace);
                    return RedirectToAction("Details", new { id = (int)Session["idCompetition"] });
                }
                catch(Exception ex)
                {
                    TempData["ErrorAddSwimmer"] = "Plivača je nemoguće prijaviti na trku jer to nije njegova kategorija";
                    return RedirectToAction("AddSwimmersToRace", new { id = (int)Session["idRace"] });
                }
            }
            else
            {
                TempData["ErrorAddSwimmer"] = "Plivača je nemoguće prijaviti na trku jer to nije njegova kategorija";
                return RedirectToAction("AddSwimmersToRace", new { id = (int)Session["idRace"] });
            }




        }
    }
}
