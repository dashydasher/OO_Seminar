﻿using Newtonsoft.Json;
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
    public class RecordController : ApiController
    {
        // GET: tables/Record
        public IEnumerable<Record> Get()
        {
            var clas = new RecordsRepository();
            var records = clas.getAllRecords();
            var recordsList = new List<Record>();
            foreach (var d in records)
            {
                recordsList.Add(d);
            }
            return recordsList;
        }

        // GET: tables/Record/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: tables/Record
        public void Post([FromBody]string value)
        {
        }

        // PUT: tables/Record/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: tables/Record/5
        public void Delete(int id)
        {
        }
    }
}
