using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class HallController : ApiController
    {
        // GET: api/Country
        public IEnumerable<Hall> Get()
        {
            var clas = new HallRepository();
            var drzave = clas.getHalls();
            var listaImena = new List<Hall>();
            foreach (var d in drzave)
            {
                listaImena.Add(d);
            }
            return listaImena;
        }

        // GET: api/Country/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }
    }
}
