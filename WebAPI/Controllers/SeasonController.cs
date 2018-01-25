using Newtonsoft.Json;
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
    public class SeasonController : ApiController
    {
        // GET: tables/Season
        public IEnumerable<Season> Get()
        {
            var clas = new SeasonRepository();
            var seasons = clas.getAllSeasons();
            var seasonsList = new List<Season>();
            foreach (var d in seasons)
            {
                seasonsList.Add(d);
            }
            return seasonsList;
        }

        // GET: tables/Season/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: tables/Season
        public void Post([FromBody]string value)
        {
        }

        // PUT: tables/Season/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: tables/Season/5
        public void Delete(int id)
        {
        }
    }
}
