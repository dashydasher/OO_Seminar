using Plivanje.Models;
using Plivanje.Processors;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClubController : ApiController
    {
        // GET: tables/Club
        public IEnumerable<Club> Get()
        {
            var clas = new ClubRepository();
            return clas.getClubs();
        }

        // GET: tables/Club/5
        public Club Get(int id)
        {
            var clas = new ClubRepository();
            return clas.getClub(id);
        }

        // POST: tables/Club
        public IHttpActionResult Post([FromBody]Club model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clubProcessor = new ClubProcessor();
            clubProcessor.UpdateClub(model);
            return Ok();
        }

        // PUT: tables/Club/5
        public IHttpActionResult Put(int id, [FromBody]Club model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clubProcessor = new ClubProcessor();
            Club race = clubProcessor.getClub(id);
            race = model;
            clubProcessor.UpdateClub(race);
            return Ok();
        }

        // DELETE: tables/Club/5
        public IHttpActionResult Delete(int id)
        {
            var clubProcessor = new ClubProcessor();
            clubProcessor.deleteClub(id);
            return Ok();
        }
    }
}
