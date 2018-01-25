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
    public class CategoryController : ApiController
    {
        // GET: tables/Record
        public IEnumerable<Category> Get()
        {
            var clas = new CategoryRepository();
            var categories = clas.getCategories();
            var categoriesList = new List<Category>();
            foreach (var d in categories)
            {
                categoriesList.Add(d);
            }
            return categoriesList;
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
