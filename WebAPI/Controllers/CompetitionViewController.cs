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
    public class CompetitionViewController : ApiController
    {
        // GET: tables/SwimmerView
        public IEnumerable<CompetitionView> Get()
        {
            var repo = new CompetitionRepository();
            var items = repo.GetListOfCompetitionView();
            var myList = new List<CompetitionView>();
            foreach (var item in items)
            {
                myList.Add(item);
            }
            return myList;
        }

        // GET: tables/SwimmerView/5
        public CompetitionView Get(int id)
        {
            var repo = new CompetitionRepository();
            return repo.GetCompetitionView(id);
        }
    }
}
