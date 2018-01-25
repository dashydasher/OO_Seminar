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
    public class ClubViewController : ApiController
    {
        // GET: tables/ClubView
        public IEnumerable<ClubView> Get()
        {
            var repo = new ClubRepository();
            var items = repo.GetListOfClubView();
            var myList = new List<ClubView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: tables/ClubView/5
        public ClubView Get(int id)
        {
            var repo = new ClubRepository();
            return repo.GetClubView(id);
        }
    }
}
