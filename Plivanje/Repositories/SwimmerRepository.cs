using NHibernate.Linq;
using Plivanje.Models;
using Plivanje.Processors;
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
        bool IsSwimmerFree(int swimmerId);
        void UpdateSwimmerSeason(SwimmerSeason swimmerSeason);
        Category GetSwimmerCategory(Swimmer swimmer);
        List<Swimmer> GetSwimmersByCategory(Category category);
        SwimmerSeason GetSwimmerSeason(int swimmerId);
        void deleteSwimmerFromClub(SwimmerSeason swSeason);
        Club GetMyClub(int swimmerId, int seasonId);
        

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

        public List<Swimmer> GetListOfSwimmers(string clubName)
        {
            var result = new List<Swimmer>();
            var klasa = new FluentNHibernateClass();
            Season season = null;
            Club club = null;
            using (var session = klasa.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Swimmer>)session.QueryOver<SwimmerSeason>().JoinAlias(x=>x.Club, () => club).JoinAlias(x=>x.Season,()=>season).Where(() => season.TimeEnd > DateTime.Now && club.Name==clubName).Select(x=>x.Swimmer).List<Swimmer>();
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
            List<LicenceSwimmer> r = null;
            var clas = new FluentNHibernateClass();
            var result = false;
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    r = (List<LicenceSwimmer>)session.QueryOver<LicenceSwimmer>().JoinQueryOver(x=>x.Swimmer).Where(x=>x.Id==idSwimmer).List<LicenceSwimmer>();
                    if (r != null)
                    {
                        foreach(var sezona in r)
                        {
                            if (sezona.Season.TimeEnd > DateTime.Now)
                            {
                                result = true;
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }
        
        
    

        public List<Swimmer> SwimmersInClub(int clubId)
        {
            Club club = null;
            Season season = null;
            var result=new List<Swimmer>();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<Swimmer>)session.QueryOver<SwimmerSeason>().JoinAlias(x => x.Club, () => club).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && club.Id==clubId).Select(x => x.Swimmer).List<Swimmer>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateSwimmerLicence(Swimmer swimmer)
        {
            SeasonProcessor sp = new SeasonProcessor();
            Licence l = new Licence();
            l.IssueDate = DateTime.Now;
            l.Number = swimmer.DateOfBirth.Day + 10000;
            Season s = sp.getNowSeason();
            
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

        public void UpdateSwimmerSeason(SwimmerSeason swimmerSeason)
        {
           
            var clas = new FluentNHibernateClass();

            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(swimmerSeason);
                    
                    transaction.Commit();
                }
            }
           
        }

        public bool IsSwimmerFree(int swimmerId)
        {
            bool free = false;
            Swimmer result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = session.Query<SwimmerSeason>().Where(x => x.Swimmer.Id == swimmerId && (x.Season.TimeEnd.Date > DateTime.Now.Date)).Select(x=>x.Swimmer).SingleOrDefault<Swimmer>();
                    if (result != null)
                    {
                        free= false;

                    }
                    else
                    {
                        free= true;
                    }
                    transaction.Commit();
                }
                
            }
            return free;

        }
        public Category GetSwimmerCategory(Swimmer swimmer)
        {
            Category result = new Category();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = session.Query<Category>().Where(x => x.AgeFrom <=( DateTime.Now.Year - swimmer.DateOfBirth.Year) && (x.AgeTo >= (DateTime.Now.Year - swimmer.DateOfBirth.Year))).ToList().FirstOrDefault();
                    
                    transaction.Commit();
                }

            }
            return result;
        }

        public List<Swimmer> GetSwimmersByCategory(Category category)
        {
            List<Swimmer> result = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (List<Swimmer>)session.Query<Swimmer>().Where(x => category.AgeFrom <= (DateTime.Now.Year - x.DateOfBirth.Year) && (DateTime.Now.Year - x.DateOfBirth.Year) <= category.AgeTo).ToList<Swimmer>();

                    transaction.Commit();
                }
            }
            return result;
        }

        public SwimmerSeason GetSwimmerSeason(int swimmerId)
        {
            SwimmerSeason result = null;
            Swimmer swimmer = null;
            Season season = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = session.QueryOver<SwimmerSeason>().JoinAlias(x => x.Swimmer, () => swimmer).JoinAlias(x => x.Season, () => season).Where(() => season.TimeEnd > DateTime.Now && swimmer.Id == swimmerId).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }

        public void deleteSwimmerFromClub(SwimmerSeason swSeason)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    session.Delete(swSeason);

                    transaction.Commit();
                }
            }
            
        }

        public Club GetMyClub(int swimmerId, int seasonId)
        {
            Club result = new Club();
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    result = (Club)session.Query<SwimmerSeason>().Where(x => x.Swimmer.Id == swimmerId && x.Season.Id == seasonId).Select(x => x.Club).SingleOrDefault();

                    transaction.Commit();
                }
            }
            return result;
        }


    }
    }

    



