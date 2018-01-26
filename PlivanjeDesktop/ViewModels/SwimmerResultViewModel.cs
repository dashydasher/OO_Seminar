using Plivanje.Models;
using Plivanje.Processors;
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
        public SwimmerRace sr { get; set; }

        public void LoadRace(int idSwimmer, int idRace)
        {
            sr = rp.GetSwimmerRace(idSwimmer, idRace);
            
        }

        public string UpdateSwimmerRace(string resultText, string scoreText)
        {
            int score = Int32.Parse(scoreText);
            if (score == 0)
                return "Vrijednost bodova ne smije biti 0";
            DateTime d;
            if (DateTime.TryParse(resultText, out d))
            {
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
