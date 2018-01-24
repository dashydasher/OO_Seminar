using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class UserViewModel
    {
        public bool CheckUser(string email, string password)
        {
            var cp = new CoachProcessor();
            var lp = new LicenceProcessor();
            List<Coach> treneri = cp.getCoaches();
            foreach (var trener in treneri)
            {
                if (email.Equals(trener.EMail.Trim()))
                    if (password.Equals(trener.Password.Trim()))
                    {
                        if (lp.CoachHasLicence(trener.Id))
                        {
                            UserModel.Id = trener.Id;
                            UserModel.role = "trener";
                            return true;
                        }
                        else
                            return false;
                    }
                    else return false;
            }


            var rf = new RefereeProcessor();
            List<Referee> suci = rf.getReferees();
            foreach (var sudac in suci)
            {
                if (email.Equals(sudac.EMail.Trim()))
                    if (password.Equals(sudac.Password.Trim()))
                    {
                        if (lp.RefereeHasLicence(sudac.Id))
                        {
                            UserModel.Id = sudac.Id;
                            UserModel.role = "sudac";
                            return true;
                        }
                        else
                            return false;
                    }
                    else return false;
            }
            return false;
        }
    }
}
