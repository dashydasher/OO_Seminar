using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlivanjeWebApp.Models;
using Plivanje.Processors;
using Plivanje.Models;

namespace WebApp.Controllers
{
    public class RecordsController : Controller
    {
        // GET: Records
        public ActionResult Index()
        {
            RecordsViewModel model = new RecordsViewModel();
            List<Record> muski = new List<Record>();
            List<Record> zenski = new List<Record>();
            List<RecordViewModel> m = new List<RecordViewModel>();
            List<RecordViewModel> z = new List<RecordViewModel>();
            var hp = new RecordsProcessor();
            muski = hp.getManRecords();
            zenski = hp.getWomanRecords();

            foreach (Record r in muski)
            {
                
                RecordViewModel pom = new RecordViewModel();
               
                pom.Category = r.Category;
                pom.Date = r.Date;
                pom.DateOfBirth = r.DateOfBirth;
                pom.FirstName = r.FirstName;
                pom.Gender = (char)r.Gender;
                pom.LastName = r.LastName;
                pom.Length = r.Length;
                pom.Place = r.Place;
                pom.RaceTime=r.RaceTime;
                pom.Style = r.Style;
               m.Add(pom);
                

            }
            model.man = m;

            foreach (Record r in zenski)
            {

                RecordViewModel pom = new RecordViewModel();

                pom.Category = r.Category;
                pom.Date = r.Date;
                pom.DateOfBirth = r.DateOfBirth;
                pom.FirstName = r.FirstName;
                pom.Gender =(char) r.Gender;
                pom.LastName = r.LastName;
                pom.Length = r.Length;
                pom.Place = r.Place;
                pom.RaceTime =r.RaceTime;
                pom.Style = r.Style;
               z.Add(pom);


            }
            model.women = z;
            return View(model);
            return View();
        }

        // GET: Records/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
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

        // GET: Records/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Records/Edit/5
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

        // GET: Records/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Records/Delete/5
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
