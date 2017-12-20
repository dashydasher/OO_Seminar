using Plivanje;
using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var klasa = new FluentNHibernateClass();
            var city = new Place { Name = "Rijeka", PostalCode = 51000 };
            //klasa.Store(city);
            klasa.TestMe();
            Console.ReadLine();
        }
    }
}
