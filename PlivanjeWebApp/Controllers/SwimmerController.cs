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
    public class SwimmerController : Controller
    {
       
        // GET: Swimmer
        public ActionResult Index(string klub)
        {
           
                var SwimmerProcessor = new SwimmerProcessor();
                var Cp = new ClubProcessor();
                var Swimmers = new List<SwimmerViewModel>();
            List<string> names = new List<string>();
            
                foreach(var c in Cp.getClubs()) {
                names.Add(c.Name);
                }
            ViewBag.klub = new SelectList(names);

            try
               
                {
                var mySwimmers=new List<Swimmer>();


                if (!String.IsNullOrEmpty(klub)){
                  mySwimmers = SwimmerProcessor.GetListOfSwimmers(klub);
                }
                else {
                  mySwimmers = SwimmerProcessor.GetListOfSwimmers();
                }
                    foreach (var item in mySwimmers)
                    {
                        SwimmerViewModel Swimmer = new SwimmerViewModel();
                        Swimmer.Id = item.Id;
                        Swimmer.lastName = item.LastName;
                        Swimmer.firstName = item.FirstName;
                        Swimmer.dateOfBirth = item.DateOfBirth.Date;
                        Swimmer.gender = item.Gender;

                    Swimmer.licenceValid = SwimmerProcessor.getSwimmerLicence(item.Id);
                    
                       
                        Swimmers.Add(Swimmer);
                    }
                }
                catch (Exception e)
                {
                    //players = null;
                }


            if (Session["UserName"] != null)
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
                    if (swimmer.licenceValid == true) //želimo novog licencirat
            {
                SwimmerProcessor.UpdateSwimmerLicence(s);
            }
                return RedirectToAction("AddSwimmerToClub","Club");
            }
            catch
            {
                return View();
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
