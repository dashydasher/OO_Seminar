using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.Models
{
    class SwimmerRaceModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Club currentClub { get; set; }
        public Category currentCategory { get; set; }
        public int Score { get; set; }
        public int RaceId { get; set; }
    }
}
