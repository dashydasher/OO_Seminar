using System;
using System.Collections.Generic;
using System.Linq;
using Plivanje.Models;
using Plivanje.Processors;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class SwimmerViewModel
    {
        public List<Swimmer> swimmers { get; set; }

        public List<Swimmer> LoadSwimmersByClub(int clubId)
        {

            var cp = new ClubProcessor();
            //var list = cp.getSwimmers(clubId);
            //foreach (var swimmer in list) {
            //    swimmers.Add(new SwimmerView
            //    {
            //        FirstName = swimmer.FirstName,
            //        LastName = swimmer.LastName,
            //        Id = swimmer.Id,
            //        DateOfBirth = swimmer.DateOfBirth,
            //        Gender = swimmer.Gender,
            //        currentCategory = swimmer.
            //    });
            //}
            swimmers = cp.getSwimmers(clubId);
            return swimmers;
        }

        public void LoadSwimmersByClub(string clubName)
        {

            var cp = new SwimmerProcessor();

            swimmers = cp.GetListOfSwimmers(clubName);
        }

        public void LoadSwimmers()
        {
            var sp = new SwimmerProcessor();
            swimmers = sp.GetListOfSwimmers();
        }

        public void LoadSwimmers(string categoryName)
        {
            var cp = new CategoryProcessor();
            var category = cp.getCategoryByName(categoryName);
            var sp = new SwimmerProcessor();
            swimmers = sp.getSwimmersByCategory(category);
        }
    }

    class SwimmerView : Swimmer
    {
        public Club currentClub { get; set; }
        public Category currentCategory { get; set; }
    }
}
