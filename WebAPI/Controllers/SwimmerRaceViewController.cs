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
        // GET: tables/SwimmerView
        public IEnumerable<SwimmerRaceView> Get()
        {
            var repo = new RaceRepository();
            var items = repo.GetListOfSwimmerRaceView();
            var myList = new List<SwimmerRaceView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: tables/SwimmerView/5
        public SwimmerRaceView Get(int id)
        {
            var repo = new RaceRepository();
            return repo.GetSwimmerRaceView(id);
        }
    }
}
