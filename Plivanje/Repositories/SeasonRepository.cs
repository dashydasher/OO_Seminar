﻿using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{ 
    public interface ISeasonRepository
        {

             Season getNowSeason();
        }

    public class SeasonRepository : ISeasonRepository
    {
        public Season getNowSeason()
        {
            var result = new Season();
            var klasa = new FluentNHibernateClass();
            
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Season>().Where(x => x.TimeEnd > DateTime.Now).List().FirstOrDefault();
                  
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
