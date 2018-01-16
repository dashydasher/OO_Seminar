using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface ISwimmerRepository
    {
        Swimmer GetSwimmer(int id);
        void UpdateSwimmer(Swimmer swimmer);
        List<Swimmer> GetListOfSwimmers();
        void StoreSwimmerChanges(Swimmer swimmer);
        bool getSwimmerLicence(int idSwimmer);
        List<Swimmer> SwimmersInClub(int clubId);
        void UpdateSwimmerLicence(Swimmer swimmer);
        List<Swimmer> GetListOfSwimmers(string club);


    }

    public class SwimmerRepository : ISwimmerRepository
    {



        public Swimmer GetSwimmer(int swimmerId)
        {
            var result = new Swimmer();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Swimmer)session.QueryOver<Swimmer>().Where(x => x.Id == swimmerId).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateSwimmer(Swimmer swimmer)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(swimmer);
                    transaction.Commit();
                }
            }
        }

        public List<Swimmer> GetListOfSwimmers()
        {
            List<Swimmer> result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<Swimmer>)session.QueryOver<Swimmer>().List<Swimmer>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Swimmer> GetListOfSwimmers(string club)
        {
            List<Swimmer> result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<Swimmer>)session.QueryOver<SwimmerSeason>().Where(x=>x.Club.Name==club).List<Swimmer>();

                    transaction.Commit();
                }
            }
            return result;
        }
        public void StoreSwimmerChanges(Swimmer swimmer)
        {
            var _swimmer = new Swimmer();
            if (swimmer.Id != 0)
            {
                _swimmer = GetSwimmer(swimmer.Id);
                _swimmer.FirstName = swimmer.FirstName;
                _swimmer.LastName = swimmer.LastName;
                _swimmer.DateOfBirth = swimmer.DateOfBirth;
                _swimmer.Gender = swimmer.Gender;
                
            }
            else
            {
                _swimmer = swimmer;
             
            }

            UpdateSwimmer(_swimmer);
        }

        public bool getSwimmerLicence(int idSwimmer)
        {
            LicenceSwimmer r = null;
            var clas = new FluentNHibernateClass();
            var result = false;
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    r = session.QueryOver<LicenceSwimmer>().Where(x=>x.Swimmer.Id==idSwimmer).SingleOrDefault();
                    if (r != null)
                    {
                        if (r.Season.TimeEnd > DateTime.Now)
                        {
                            result = true;
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }
        
        
    

        public List<Swimmer> SwimmersInClub(int clubId)
        {
            List<Swimmer> result=new List<Swimmer>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<Swimmer>)session.QueryOver<SwimmerSeason>().Where(x=>x.Club.Id==clubId).Select(c=>c.Swimmer).List<Swimmer>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateSwimmerLicence(Swimmer swimmer)
        {
            Licence l = new Licence();
            l.IssueDate = DateTime.Now;
            l.Number = swimmer.DateOfBirth.Day + 10000;
            Season s = new Season();
            s.TimeStart = DateTime.Parse("01.01.2018.");
            s.TimeEnd = s.TimeStart.AddYears(1);
            LicenceSwimmer licence = new LicenceSwimmer();
            licence.Season = s;
            licence.Swimmer = swimmer;
            licence.Licence = l;
            var clas = new FluentNHibernateClass();

            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(l);
                    session.SaveOrUpdate(s);
                    transaction.Commit();
                }
            }
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(licence);
                    transaction.Commit();
                }
            }
        }
    }

    }



