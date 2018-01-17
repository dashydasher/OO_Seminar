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
    }
}
