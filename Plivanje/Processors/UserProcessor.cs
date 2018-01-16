using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
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

    }
}
