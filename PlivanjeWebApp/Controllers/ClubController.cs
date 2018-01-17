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
    public class ClubController : Controller
    {
        // GET: Club
        public ActionResult Index()
        {
            List<ClubViewModel> model = new List<ClubViewModel>();
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();

            foreach(Club c in list)
            {
                ClubViewModel pom = new ClubViewModel();
                CoachSeason pom2 = new CoachSeason();
                Coach coach = new Coach();
                Season season = new Season();
                pom.Id = c.Id;
                pom.Address = c.Address;
                pom.Name = c.Name;

                pom.Place = cp.getPlace(c.Place.Id).Name;
                pom2 = cp.getSeasonCoach(pom.Id);
                if (pom2 != null)
                {
                    season = cp.getSeason(pom2.Season.Id);
                    if (season != null && season.TimeEnd > DateTime.Now)
                    {
                        coach = cp.getCoach(pom2.Coach.Id);
                        pom.coach = coach;
                    }
                }
                //pom.swimmers = cp.getSwimmers(c.Id);
                model.Add(pom);
                
            }
            if (Session["role"] != null)
            {
                if ((int)Session["role"] == 1) {
                    return View(model);
                }

            }
            return View("ListOnlyView", model);
            
        }

        // GET: Club/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: MyClub
        public ActionResult MyClub()
        {
            Club c = new Club();
            ClubViewModel club = new ClubViewModel();
            CoachSeason season = new CoachSeason();
            List<SwimmerViewModel> swimmInClub = new List<SwimmerViewModel>();
            var sp = new SwimmerProcessor();
            var cp = new ClubProcessor();

            List<Swimmer> swimmers = new List<Swimmer>();

            int i = cp.getMyClubId((int)Session["UserId"]);
            Session["clubId"] = i;
            c = cp.getClub(i);
            club.Id = c.Id;
            club.Name = c.Name;
            club.Place = cp.getPlace(c.Place.Id).Name;
            club.Address = c.Address;
            swimmers = sp.SwimmersInClub(club.Id);
            foreach(var s in swimmers)
            {
                Swimmer plivac = sp.getSwimmer(s.Id);
                SwimmerViewModel pom = new SwimmerViewModel();
                pom.Id = plivac.Id;
                pom.firstName = plivac.FirstName;
                pom.lastName = plivac.LastName;
                pom.gender = plivac.Gender;
                pom.dateOfBirth = plivac.DateOfBirth;

                pom.licenceValid = sp.getSwimmerLicence(plivac.Id);

                swimmInClub.Add(pom);
                


            }
            club.swimmers = swimmInClub;
            return View(club);
        }
        public ActionResult AddSwimmerToClub()
        {
            List<SwimmerViewModel> model = new List<SwimmerViewModel>();
            List<Swimmer> pom = new List<Swimmer>(); // u pom idu svi plivači koji trenutno nisu u tom ili u nekom drugom klubu

            SwimmerProcessor sp = new SwimmerProcessor();
            pom = sp.GetListOfSwimmers();
            foreach (var p in pom)
            {
                if (sp.IsSwimmerFree(p.Id))
                {
                    SwimmerViewModel s = new SwimmerViewModel();
                    s.Id = p.Id;
                    s.lastName = p.LastName;
                    s.firstName = p.FirstName;
                    s.dateOfBirth = p.DateOfBirth;
                    s.gender = p.Gender;
                    model.Add(s);
                }
            }
            


            return View(model);
        }
        
        public ActionResult AddSwimmerToClubPost(int id)
        {
            SwimmerSeason swimmerSeason = new SwimmerSeason();
            var sp = new SwimmerProcessor();
            var cp = new ClubProcessor();
            var season = new SeasonProcessor();
            Club c = new Club();
            c = cp.getClub((int)Session["clubId"]);
            Season s = new Season();
            s = season.getNowSeason(2);
            Category cat = new Category();
            Swimmer swim = new Swimmer();
            swim = sp.getSwimmer(id);
            cat = sp.GetSwimmerCategory(swim);

            swimmerSeason.Season = s;
            swimmerSeason.Swimmer = swim;
            swimmerSeason.Club = c;
            swimmerSeason.Category = cat;
            try
            {
                if (ModelState.IsValid)
                {
                    sp.UpdateSwimmerSeason(swimmerSeason);
                    return RedirectToAction("MyClub");
                }
            }
            catch (Exception e)
            {

                return View();
            }

            return View();
        }
        // POST: Club/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Club/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Club/Edit/5
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

        // GET: Club/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Club/Delete/5
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
    }
}
