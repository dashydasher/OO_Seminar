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
            var rp = new RefereeProcessor();
            List<RaceViewModel> model = new List<RaceViewModel>();
            List<Race> races = rp.GetMyRaces((int)Session["UserId"]);
            foreach(var r in races)
            {
                model.Add(new RaceViewModel
                {
                    Id = r.Id,
                    categoryName = r.Category.Name,
                    datum = r.TimeStart.Date,
                    start = r.TimeStart,
                    finish = r.TimeEnd,
                    sytleName = r.Style.Name,
                    lenghtValue = r.Length.Len,
                    Gender = r.Gender

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
            model.Id = tmp2.Id;
            model.Category = tmp2.Category;
            model.Style = tmp2.Style;
            model.Length = tmp2.Length;
            model.Gender = tmp2.Gender;
            model.datum = tmp2.TimeStart.Date;
            model.start = tmp2.TimeStart;
            model.finish = tmp2.TimeEnd;
            model.swimmers = tmp1;

            return View(model);
        }

        // POST: Race/Edit/5
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
