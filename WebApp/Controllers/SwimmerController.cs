using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using Plivanje.Processors;
using Plivanje.Models;

namespace WebApp.Controllers
{
    public class SwimmerController : Controller
    {
       
        // GET: Swimmer
        public ActionResult Index()
        {
           
                var SwimmerProcessor = new SwimmerProcessor();

                var Swimmers = new List<SwimmerViewModel>();

                try
                {
                    var mySwimmers = SwimmerProcessor.GetListOfSwimmers();

                    foreach (var item in mySwimmers)
                    {
                        SwimmerViewModel Swimmer = new SwimmerViewModel();
                        Swimmer.Id = item.Id;
                        Swimmer.lastName = item.LastName;
                        Swimmer.firstName = item.FirstName;
                        Swimmer.dateOfBirth = item.DateOfBirth;
                        Swimmer.gender = item.Gender;

                       LicenceSwimmer lic = new LicenceSwimmer();
                        lic = SwimmerProcessor.getSwimmerLicence(Swimmer.Id);
                        Swimmer.licence = lic;
                        Swimmers.Add(Swimmer);
                    }
                }
                catch (Exception e)
                {
                    //players = null;
                }

               
            
            return View(Swimmers);
        }

        // GET: Swimmer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Swimmer/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Swimmet/Create
        [HttpPost]
        public ActionResult Create(SwimmerViewModel swimmer)
        {
            

            var SwimmerProcessor = new SwimmerProcessor();
            Swimmer s = new Swimmer();
            s.DateOfBirth = swimmer.dateOfBirth;
            s.FirstName = swimmer.firstName;
            s.LastName = swimmer.lastName;
            if (swimmer.spol == "M")
            {
                s.Gender = Gender.M;
            }
            else
            {
                s.Gender = Gender.Ž;
            }
            try
            {

                SwimmerProcessor.UpdateSwimer(s);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Swimmet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Swimmet/Edit/5
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

        // GET: Swimmet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Swimmet/Delete/5
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
