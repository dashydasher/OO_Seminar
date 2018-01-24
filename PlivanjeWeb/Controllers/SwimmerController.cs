using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlivanjeWeb.Models;
using Plivanje.Processors;
using Plivanje.Models;
using PlivanjeWebApp.Controllers;

namespace WebApp.Controllers
{
    public class SwimmerController : Controller
    {
       
        // GET: Swimmer
        public ActionResult Index(string klub,string kategorija)
        {
                var categoryProcessor = new CategoryProcessor();
                var SwimmerProcessor = new SwimmerProcessor();
                var Cp = new ClubProcessor();
                var Swimmers = new List<SwimmerViewModel>();
            List<string> names1 = new List<string>();
            List<string> names2 = new List<string>();

            var categories = categoryProcessor.getCategories();
            foreach(var c in categories)
            {
                names1.Add(c.Name);
            }
            ViewBag.kategorija = new SelectList(names1);
           
                
            
                foreach(var c in Cp.getClubs()) {
                names2.Add(c.Name);
                }
            ViewBag.klub = new SelectList(names2);

            try
               
                {
                var mySwimmers=new List<Swimmer>();

                if (!String.IsNullOrEmpty(klub) && !String.IsNullOrEmpty(kategorija))
                {
                    mySwimmers = SwimmerProcessor.GetSwimmersByCategoryAndClub(klub,kategorija);
                }
               else if (!String.IsNullOrEmpty(kategorija))
                {
                    mySwimmers = SwimmerProcessor.GetSwimmersByCategory(kategorija);
                }

               else if (!String.IsNullOrEmpty(klub)){
                  mySwimmers = SwimmerProcessor.GetListOfSwimmers(klub);
                }
                
                else {
                  mySwimmers = SwimmerProcessor.GetListOfSwimmers();
                }
                    foreach (var s in mySwimmers)
                    {
                    Swimmer item = SwimmerProcessor.getSwimmer(s.Id);
                        SwimmerViewModel Swimmer = new SwimmerViewModel();
                        Swimmer.Id = item.Id;
                        Swimmer.lastName = item.LastName;
                        Swimmer.firstName = item.FirstName;
                        Swimmer.dateOfBirth = item.DateOfBirth.Date;
                        Swimmer.gender = item.Gender;
                        Swimmer.category = SwimmerProcessor.GetSwimmerCategory(item).Name;
                        Swimmer.licenceValid = SwimmerProcessor.getSwimmerLicence(item.Id);
                    
                       
                        Swimmers.Add(Swimmer);
                    }
                }
                catch (Exception e)
                {
                    //players = null;
                }


            if (HttpContext.Session["UserName"] != null)
            {
                return View(Swimmers);
            }
            else
            {
                return View("ListOnlyView", Swimmers);
            }
            
        }

        // GET: Swimmer/Details/5
        public ActionResult Details(int id)
        {
            SwimmerProcessor sp = new SwimmerProcessor();
            Swimmer s=sp.getSwimmer(id);
            List<SwimmerSeason> tmp = sp.GetSwimmerSeasons(id);
            List<SwimmerRace> tmp2 = sp.GetSwimmerRaces(id);

            SwimmerDetailsViewModel model = new SwimmerDetailsViewModel();
            model.dateOfBirth = s.DateOfBirth;
            model.firstName = s.FirstName;
            model.lastName = s.LastName;
            model.seasons = tmp;
            model.races = tmp2;
            return View(model);
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
            if (s.DateOfBirth > DateTime.Now)
            {
                TempData["Error"] = "Rođendan plivača ne smije biti u budućnosti";
                return RedirectToAction("Create");
            }
            if(String.IsNullOrEmpty(swimmer.firstName) || String.IsNullOrEmpty(swimmer.lastName))
            {
                TempData["Error"] = "Ime i prezime su obavezna polja";
                return RedirectToAction("Create");
            }
            else
            {
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
                    if (swimmer.licenceValid == true) //želimo novog licencirat
                    {
                        SwimmerProcessor.UpdateSwimmerLicence(s);
                    }
                    return RedirectToAction("AddSwimmerToClub", "Club");
                }
                catch
                {
                    TempData["Error"] = "Došlo je do pogreške prilikom spremanja";
                    return RedirectToAction("Create");
                }
            }
        }

        // GET: Swimmet/Edit/5
        public ActionResult Edit(int id)
        {
            SwimmerViewModel model = new SwimmerViewModel();
            Swimmer s = new Swimmer();
            SwimmerProcessor sp = new SwimmerProcessor();
            s = sp.getSwimmer(id);
            model.Id = s.Id;
            model.firstName = s.FirstName;
            model.lastName = s.LastName;
            model.dateOfBirth = s.DateOfBirth.Date;
            model.gender = s.Gender;
            
            model.licenceValid = sp.getSwimmerLicence(s.Id);

            return View(model);
        }

        // POST: Swimmet/Edit/5
        [HttpPost]
        public ActionResult Edit(SwimmerViewModel swimmer)
        {

            var SwimmerProcessor = new SwimmerProcessor();
            Swimmer s = new Swimmer();
            s = SwimmerProcessor.getSwimmer(swimmer.Id);
            

          

            try
            {

                SwimmerProcessor.UpdateSwimer(s);
                if (swimmer.licenceValid == true) //želimo novog licencirat
                {
                    SwimmerProcessor.UpdateSwimmerLicence(s);
                }
                return RedirectToAction("MyClub", "Club");
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
