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
    class SwimmerResultViewModel
    {
        RaceProcessor rp = new RaceProcessor();
        SwimmerProcessor sp = new SwimmerProcessor();
        public SwimmerResultModel srm { get; set; }

        public void LoadRace(int idSwimmer, int idRace, int idSwimmerRace)
        {
            srm = new SwimmerResultModel
            {
                Swimmer = sp.getSwimmer(idSwimmer),
                IdRace = idRace,
                Id = idSwimmerRace
            };
            
        }

        public string UpdateSwimmerRace(string resultText, string scoreText)
        {
            int score = Int32.Parse(scoreText);
            if (score == 0)
                return "Vrijednost bodova ne smije biti 0";

            SwimmerRace sr;
            DateTime d;
            if (DateTime.TryParse(resultText, out d))
            {
                //srm.RaceTime = d;
                //srm.Score = score;
                sr = rp.GetSwimmerRace(srm.Id);
                sr.RaceTime = d;
                sr.Score = score;
                rp.UpdateSwimmerRace(sr);
            }
            else
            {
                return "Vrijednost rezultata utrke treba biti u obliku HH:MM:SS";
            }

            return "Rezultat uspješno zapisan";
        }
    }
}
