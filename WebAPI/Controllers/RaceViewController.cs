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
    public class RaceViewController : ApiController
    {
        // GET: tables/RaceView
        public IEnumerable<RaceView> Get()
        {
            var repo = new RaceRepository();
            var items = repo.getRaceViews();
            var myList = new List<RaceView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: tables/RaceView/5
        public RaceView Get(int id)
        {
            var repo = new RaceRepository();
            return repo.getRaceView(id);
        }
    }
}
