using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Repositories
{
    public interface IUserRepository
    {
        RegisteredPerson GetUserByUsernameAndPassword(string email, string password, int roleId);
        //IList<ClubPlayers> GetListOfClubPlayers(int id);
        //RegisteredPerson GetRegisteredPerson(int id);
        //void SaveUpdateRegisteredPerson(RegisteredPerson RegisteredPerson);
        //List<User> GetUsers();
        int GetType(string email,string pass);
        RegisteredPerson GetRegisteredPersonFromUserId(int id);
    }

    public class UserRepository : IUserRepository
    {
        public RegisteredPerson GetUserByUsernameAndPassword(string email, string password, int roleId)
        {
            RegisteredPerson result;
            var clas = new FluentNHibernateClass();
            if (roleId == 1)
            {
                using (var session = clas.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        result = session.QueryOver<Coach>().Where(u => (u.Password == password) && (u.EMail==email)).List().FirstOrDefault();
                        transaction.Commit();
                    }
                }
            }
            else
            {
                using (var session = clas.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        result = session.QueryOver<Referee>().Where(u => (u.Password == password) && (u.EMail==email) ).List().FirstOrDefault();
                        transaction.Commit();
                    }
                }
            }
            return result;
        }

 

       
        public int GetType(string email,string pass)
        {
            
            var clas = new FluentNHibernateClass();
            
            RegisteredPerson result=null;
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<Coach>().Where(x => x.EMail == email && x.Password == pass).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            if (result!=null) {
                return 1;
            }
            else
            {
               RegisteredPerson r = null;
                using (var session = clas.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        r = session.QueryOver<Referee>().Where(x => x.EMail == email && x.Password == pass).List().FirstOrDefault();
                        transaction.Commit();
                    }
                }
                if (r!= null)
                {
                    return 2;
                }
            }
            return 0;
            

        }

        public void SaveUpdateRegisteredPerson(RegisteredPerson RegisteredPerson)
        {
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(RegisteredPerson);
                    transaction.Commit();
                }
            }
        }

  

        public RegisteredPerson GetRegisteredPersonFromUserId(int id)
        {
            RegisteredPerson message = null;
            var clas = new FluentNHibernateClass();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    message = session.QueryOver<RegisteredPerson>().Where(u => u.Id == id).List().First();
                    transaction.Commit();

                }
            }
            return message;
        }
    }
}
