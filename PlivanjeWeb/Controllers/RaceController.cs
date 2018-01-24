using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlivanjeWeb.Controllers
{
    public class RaceController : Controller
    {
        // GET: Race
        public ActionResult Index()
        {
            bool inserted = false;
            var rp = new RefereeProcessor();
            var raceProcessor = new RaceProcessor();
            List<RaceViewModel> model = new List<RaceViewModel>();
            List<Race> races = rp.GetMyRaces((int)Session["UserId"]);
            foreach(var r in races)
            {
                if (raceProcessor.ResultIsInserted(r.Id) != null)
                {
                   inserted = true;
                }
                model.Add(new RaceViewModel
                {
                    Id = r.Id,
                    categoryName = r.Category.Name,
                    datum = r.TimeStart.Date,
                    start = r.TimeStart,
                    finish = r.TimeEnd,
                    sytleName = r.Style.Name,
                    lenghtValue = r.Length.Len,
                    Gender = r.Gender,
                    ResultIsInserted = inserted
                

                });
            }
            return View(model);
        }

        // GET: Race/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Race/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Race/Create
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

        // GET: Race/Edit/5
        public ActionResult Edit(int id)
        {
            RaceEditViewModel model = new RaceEditViewModel();
            RaceProcessor rp = new RaceProcessor();
            List<SwimmerRace> tmp1 = rp.SwimmersOnRace(id);
            Race tmp2 = rp.getRace(id);
            List<SwimmerRaceViewModel> tmp3 = new List<SwimmerRaceViewModel>();
            foreach(var item in tmp1)
            {
                tmp3.Add(
                    new SwimmerRaceViewModel
                    {
                        Id=item.Swimmer.Id,
                        firstName=item.Swimmer.FirstName,
                        lastName=item.Swimmer.LastName,
                        dateOfBirth=item.Swimmer.DateOfBirth,
                        gender=item.Swimmer.Gender
                    }
                );
            }
            model.Id = tmp2.Id;
            model.Category = tmp2.Category;
            model.Style = tmp2.Style;
            model.Length = tmp2.Length;
            model.Gender = tmp2.Gender;
            model.datum = tmp2.TimeStart.Date;
            model.start = tmp2.TimeStart;
            model.finish = tmp2.TimeEnd;
            model.swimmers = tmp3;

            return View(model);
        }

        // POST: Race/Edit/5
        [HttpPost]
        public ActionResult Edit(RaceEditViewModel model, FormCollection collection)
        {
            var sp = new SwimmerProcessor();
            var rp = new RaceProcessor();
            try
            {
                foreach(var item in model.swimmers)
                {
                    if (item.score == 0)
                    {
                        TempData["Error"] = "Rezultat za utrku treba biti različit od 0";
                        return RedirectToAction("Edit", new { @id = model.Id });
                    }
                    DateTime d;
                    if(DateTime.TryParse(item.RaceTime.ToString(),out d))
                    {
                        SwimmerRace save = new SwimmerRace();
                        save = rp.GetSwimmerRace(model.Id, item.Id);
                        save.Swimmer = sp.getSwimmer(item.Id);
                        save.Race = rp.getRace(model.Id);
                        save.RaceTime = d;
                        save.Score = item.score;
                        rp.UpdateSwimmerRace(save);

                    }
                    else
                    {
                        TempData["Error"] = "Vrijednost za vrijeme utrke treba biti u obliku HH:MM:SS";
                        return RedirectToAction("Edit", new { @id = model.Id });
                    }
                }

             

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Vrijednost za vrijeme utrke treba biti u obliku HH:MM:SS";
                return RedirectToAction("Edit", new { @id = model.Id });
            }
        }

        // GET: Race/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Race/Delete/5
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
