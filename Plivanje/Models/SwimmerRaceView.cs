using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Models
{
    public class SwimmerRaceView : Person
    {
        public virtual string Score { get; set; }
        
        public virtual string Length { get; set; }
        
        public virtual string Style { get; set; }
        
        public virtual DateTime RaceTime { get; set; }
        
        public virtual DateTime Time { get; set; }
        
        public virtual string Gender { get; set; }
        
        public virtual string IdRace { get; set; }
        
        public virtual string IdSwimmer { get; set; }
        
        public virtual string IdCompetition { get; set; }
    }
}
