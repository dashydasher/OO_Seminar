using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje
{
    public class FluentNHibernateClass
    {

        private static ISessionFactory _sessionFactory;
        public static ISessionFactory CreateSessionFactory()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return Fluently.Configure()
                .Database(
                MsSqlConfiguration.MsSql2012
                .ConnectionString(connString).ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FluentNHibernateClass>())
                .BuildSessionFactory();
        }

        public void Store(object o)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(o);
                    transaction.Commit();
                }
            }
        }

        public void TestMe()
        {
            var settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
            //Console.WriteLine(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory();

                ISession session = _sessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}
