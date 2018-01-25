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
    public class SwimmersViewController : ApiController
    {
        // GET: value/SwimmerView
        public IEnumerable<SwimmerView> Get()
        {
            var repo = new SwimmerRepository();
            var items = repo.GetListOfSwimmerViews();
            var myList = new List<SwimmerView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: value/SwimmerView/5
        public SwimmerView Get(int id)
        {
            var repo = new SwimmerRepository();
            return repo.GetSwimmerView(id);
        }
    }
}
