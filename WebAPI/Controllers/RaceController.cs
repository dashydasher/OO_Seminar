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
    public class RaceController : ApiController
    {
        // GET: tables/Race
        public IEnumerable<Race> Get()
        {
            var clas = new RaceRepository();
            return clas.getRaces();
        }

        // GET: tables/Race/5
        public Race Get(int id)
        {
            var clas = new RaceRepository();
            return clas.getRace(id);
        }

        // POST: tables/Race
        public IHttpActionResult Post([FromBody]Race model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var raceProcessor = new RaceProcessor();
            raceProcessor.UpdateRace(model);
            return Ok();
        }

        // PUT: tables/Race/5
        public IHttpActionResult Put(int id, [FromBody]Race model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var raceProcessor = new RaceProcessor();
            Race race = raceProcessor.getRace(id);
            race = model;
            raceProcessor.UpdateRace(race);
            return Ok();
        }

        // DELETE: tables/Race/5
        public IHttpActionResult Delete(int id)
        {
            var raceProcessor = new RaceProcessor();
            raceProcessor.deleteRace(id);
            return Ok();
        }
    }
}
