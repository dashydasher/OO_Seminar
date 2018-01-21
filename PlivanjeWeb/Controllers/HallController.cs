using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlivanjeWeb.Models;
using Plivanje.Processors;
using Plivanje.Models;
using System.Diagnostics;

namespace WebApp.Controllers
{
    public class HallController : Controller
    {
        // GET: Hall
        public ActionResult Index()
        {
            List<HallViewModel> model = new List<HallViewModel>();
            List<Hall> listOfHalls = new List<Hall>() ;
            var hp = new HallProcessor();
            listOfHalls = hp.ListOfhall();
          


           

            foreach (Hall h in listOfHalls)
            {
                List<Pool> bazeni25 = new List<Pool>();
                List<Pool> bazeni50 = new List<Pool>();
                HallViewModel pom = new HallViewModel();
                List<PoolViewModel> baz = new List<PoolViewModel>();
                pom.Id = h.Id;
                pom.Address = h.Address;
                pom.Name = h.Name;
                
                //Debug.WriteLine(pom.Name);
                pom.Place = hp.getPlace(h.Place.Id).Name;
                Debug.WriteLine(pom.Place);
                bazeni25 = hp.getPools(h.Id,25);
                bazeni50 = hp.getPools(h.Id, 50);
                if (bazeni25 != null)
                {
                    pom.count25 = bazeni25.Count;
                    Debug.WriteLine(pom.count25);

                }
                if (bazeni50 != null)
                {
                    pom.count50 = bazeni50.Count;
                    Debug.WriteLine(pom.count50);

                }
                //pom.poolHall = baz;
                model.Add(pom);

                
                }

            

            return View(model);
         
        }

        // GET: Hall/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hall/Create
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

        // GET: Hall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hall/Edit/5
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

        // GET: Hall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hall/Delete/5
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
