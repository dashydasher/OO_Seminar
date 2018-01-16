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
            List<Swimmer> swimmers = new List<Swimmer>();
            var sp = new SwimmerProcessor();
            var cp = new ClubProcessor();



            int i = cp.getMyClubId((int)Session["UserId"]);
            
            c = cp.getClub(i);
            club.Id = c.Id;
            club.Name = c.Name;
            club.Place = cp.getPlace(c.Place.Id).Name;
            club.Address = c.Address;
            swimmers = sp.SwimmersInClub(club.Id);
            foreach(var s in swimmers)
            {
                Swimmer pom = new Swimmer();
                pom.FirstName = s.FirstName;
                pom.LastName = s.LastName;
                pom.Gender = s.Gender;
                pom.DateOfBirth = s.DateOfBirth;
                club.swimmers.Add(pom);
            }

            return View(club);
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
