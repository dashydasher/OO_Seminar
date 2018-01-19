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
            swimmers = cp.getSwimmers(clubId);
            return swimmers;
        }

        internal void LoadSwimmers()
        {
            var sp = new SwimmerProcessor();
            swimmers = sp.GetListOfSwimmers();
        }

        internal void LoadSwimmers(string categoryName)
        {
            var cp = new CategoryProcessor();
            var category = cp.getCategoryByName(categoryName);
            var sp = new SwimmerProcessor();
            swimmers = sp.getSwimmersByCategory(category);
        }
    }
}
