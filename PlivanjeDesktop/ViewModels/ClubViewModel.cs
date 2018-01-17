using System;
using Plivanje.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Collections;
using Plivanje.Processors;

namespace PlivanjeDesktop.ViewModels
{
    class ClubViewModel
    {
        public ObservableCollection<Club> clubs { get; set; }
        public void LoadClubs()
        {
            clubs = new ObservableCollection<Club>();
            List<Club> list = new List<Club>();
            var cp = new ClubProcessor();
            list = cp.getClubs();
            foreach (var club in list)
                clubs.Add(club);
        }
    }
}
