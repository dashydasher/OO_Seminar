using System;
using Plivanje.Processors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plivanje.Models;

namespace PlivanjeDesktop.ViewModels
{
    class RegisterViewModel
    {
        
        public bool RegisterPerson(string role, string firstName, string lastName, string email, string password, DateTime dateOfBirth)
        {
            bool success;
            var lp = new LicenceProcessor();
            if (role.Equals("trener"))
                success = registerCoach(firstName, lastName, email, password, dateOfBirth);
            else
                success = registerReferee(firstName, lastName, email, password, dateOfBirth);
            return true;
        }

        private bool registerReferee(string firstName, string lastName, string email, string password, DateTime dateOfBirth)
        {
            Referee referee = new Referee
            {
                FirstName = firstName,
                LastName = lastName,
                EMail = email,
                Password = password,
                DateOfBirth = dateOfBirth
            };
            var rp = new RefereeProcessor();
            try
            {
                rp.UpdateReferee(referee);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private bool registerCoach(string firstName, string lastName, string email, string password, DateTime dateOfBirth)
        {
            Coach coach = new Coach
            {
                FirstName = firstName,
                LastName = lastName,
                EMail = email,
                Password = password,
                DateOfBirth = dateOfBirth
            };
            var cp = new CoachProcessor();
            try
            {
                cp.UpdateCoach(coach);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
