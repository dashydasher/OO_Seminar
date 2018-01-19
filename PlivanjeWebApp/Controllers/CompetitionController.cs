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
            return View();
        }

<<<<<<< Updated upstream
=======
        private List<RaceViewModel> getRaces(int id)
        {
            var result = new List<Race>();
            var klasa = new FluentNHibernateClass();
            
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


                    transaction.Commit();
                }
            }
            return trke;
        }
>>>>>>> Stashed changes
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
            return View();
        }

        // POST: Competition/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
<<<<<<< Updated upstream
=======

        public ActionResult CreateRace(int id)
        {
            RaceViewModel race = new RaceViewModel();
            CompetitionProcessor comp = new CompetitionProcessor();
            Session["idCompetition"] = comp.GetCompetition(id).Id;
            CategoryProcessor cp = new CategoryProcessor();
            RefereeProcessor rp = new RefereeProcessor();
            StyleProcessor sp = new StyleProcessor();
            HallProcessor hp = new HallProcessor();

            List<Category> categories = cp.getCategories();
            List<Referee> referees = rp.getReferees();
            List<Style> styles = sp.getStyles();
            List<Length> len = GetLenghts();
            List<Pool> pools = hp.getPools(hp.getHallCompetition(id).Id);

            ViewBag.pools = pools;
            ViewBag.len = len;
            ViewBag.categories = categories;
            ViewBag.styles = styles;
            ViewBag.referees = referees;

            return View();
        }
        [HttpPost]
        public ActionResult CreateRace (RaceViewModel race)
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
            r.Length = GetLength(race.lenghtId);
            r.Gender = race.Gender;
            r.Competition = comp.GetCompetition((int)Session["idCompetition"]);
            
            DateTime start = new DateTime(race.TimeStart.Year, race.TimeStart.Month, race.TimeStart.Day, race.start.TimeOfDay.Hours, race.start.TimeOfDay.Minutes,race.start.TimeOfDay.Seconds);
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
            foreach(var item in swimmers)
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

       

        public List<Length> GetLenghts()
        {
            List<Length> result = new List<Length>();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Length>)session.QueryOver<Length>().OrderBy(x => x.Id).Asc.List();

                    transaction.Commit();
                }
            }
            return result;
        }

        public Length GetLength(int id)
        {
            Length result = new Length();
            var klasa = new FluentNHibernateClass();
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Length>().Where(x => x.Id==id).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }
>>>>>>> Stashed changes
    }
}
