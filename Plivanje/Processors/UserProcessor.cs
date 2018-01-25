using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{

    public class DataProcessor
    {
        private IUserRepository _repository;

        public IUserRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public DataProcessor()
        {
            _repository = new UserRepository();
        }

        public string ProccesData(string username, string password, int roleId)
        {
            var message = "";
            RegisteredPerson user = _repository.GetUserByUsernameAndPassword(username, password, roleId);
            if (user != null)
            {
                if (roleId == 3)
                {
                    RegisteredPerson person = _repository.GetRegisteredPersonFromUserId(user.Id);
                    message = person.Id.ToString();
                }
                else
                {
                    message = user.Id.ToString();
                }
            }
            return message;
        }

        public Person GetPerson(int id)
        {
            Person referee = _repository.GetRegisteredPersonFromUserId(id);
            return referee;
        }

        public string SaveUpdatePerson(int id, string ime, string prezime, string date, string email,string password,RegisteredPerson user)
        {
            var person = new Coach();
            var message = "";
            if (id != 0)
                person = (Coach)_repository.GetRegisteredPersonFromUserId(id);

            if (String.IsNullOrEmpty(ime) || String.IsNullOrEmpty(prezime) || String.IsNullOrEmpty(date) || String.IsNullOrEmpty(email) )
                message = "Nisu popunjena sva polja, popunite polja pa pokušajte ponovo";
            else
            {
                person.FirstName = ime;
                person.LastName = prezime;
                person.DateOfBirth = Convert.ToDateTime(date);
                person.EMail = email;
                person.Password = password;

                _repository.SaveUpdateRegisteredPerson(person);
                message = "Podaci su uspješno spremljeni";
            }
            return message;
        }
    }
    public class UserProcessor
    {
        private IUserRepository _repository;

        public IUserRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public UserProcessor()
        {
            _repository = new UserRepository();
        }

        public RegisteredPerson GetUserByUsernameAndPassword(string email, string password, int roleId)
        {
            return _repository.GetUserByUsernameAndPassword(email, password, roleId);
        }

       public int GetType(string email, string pass)
        {
           return _repository.GetType(email, pass);
        }

        public RegisteredPerson GetRegisteredPersonFromUserId(int id)
        {
            return _repository.GetRegisteredPersonFromUserId(id);
        }
        void SaveUpdateRegisteredPerson(RegisteredPerson RegisteredPerson)
        {
            _repository.SaveUpdateRegisteredPerson(RegisteredPerson);
        }

    }
}
