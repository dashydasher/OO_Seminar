using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SwimmerRaceViewController : ApiController
    {
        // GET: tables/SwimmerRaceView
        public IEnumerable<SwimmerRaceView> Get()
        {
            var repo = new SwimmerRepository();
            var items = repo.GetListOfSwimmerRaceViews();
            var myList = new List<SwimmerRaceView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: tables/SwimmerRaceView/5
        public SwimmerRaceView Get(int id)
        {
            var repo = new SwimmerRepository();
            return repo.GetSwimmerRaceView(id);
        }
    }
}
