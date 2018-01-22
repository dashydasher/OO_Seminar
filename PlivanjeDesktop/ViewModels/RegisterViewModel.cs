using System;
using Plivanje.Processors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class RegisterViewModel
    {
        
        public bool RegisterPerson(string role, string firstName, string lastName, string email, string password, string idLicence)
        {
            var lp = new LicenceProcessor();
            if (!lp.licenceExists(Int32.Parse(idLicence.Trim())))
                return false;
            if (role.Equals("trener"))
                registerCoach(firstName, lastName, email, password, idLicence);
            else
                registerReferee(firstName, lastName, email, password, idLicence);
            return true;
        }

        private void registerReferee(string firstName, string lastName, string email, string password, string idLicence)
        {
            //dodat suca u bazu
        }

        private void registerCoach(string firstName, string lastName, string email, string password, string idLicence)
        {
            //dodat trenera u bazu
        }
    }
}
