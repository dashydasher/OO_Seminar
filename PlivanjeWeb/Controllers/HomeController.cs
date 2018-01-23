using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CompetitionProcessor cp = new CompetitionProcessor();
            List<Competition> comp = cp.GetFutureCompetitions();
            List<CompetitionViewModel> model = new List<CompetitionViewModel>();
            if (comp != null)
            {
                
                foreach(var item in comp)
                {
                    model.Add(new CompetitionViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        TimeEnd = item.TimeEnd,
                        TimeStart = item.TimeStart,
                        HallName = item.Hall.Name

                    });
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}