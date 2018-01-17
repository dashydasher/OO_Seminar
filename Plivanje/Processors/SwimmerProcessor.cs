using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class SwimmerProcessor
    {
        private ISwimmerRepository _swimmerRepository;

        public ISwimmerRepository Repository
        {
            get { return _swimmerRepository; }
            set { _swimmerRepository = value; }
        }

        public SwimmerProcessor()
        {
            _swimmerRepository = new SwimmerRepository();
        }

        public List<Swimmer> GetListOfSwimmers()
        {
            return Repository.GetListOfSwimmers();
        }

        public Swimmer getSwimmer(int id)
        {
            return _swimmerRepository.GetSwimmer(id);
        }
        public void UpdateSwimer(Swimmer swimmer)
        {
            _swimmerRepository.UpdateSwimmer(swimmer);
        }
        public void StoreSwimmerChanges(Swimmer swimmer)
        {
            _swimmerRepository.StoreSwimmerChanges(swimmer);
        }
       public bool getSwimmerLicence(int idSwimmer)
        {
            return _swimmerRepository.getSwimmerLicence(idSwimmer);
        }

        public List<Swimmer> SwimmersInClub(int clubId)
        {
            return _swimmerRepository.SwimmersInClub(clubId);
        }

        public void UpdateSwimmerLicence(Swimmer swimmer)
        {
            _swimmerRepository.UpdateSwimmerLicence(swimmer);
        }
        public List<Swimmer> GetListOfSwimmers(string club)
        {
            return _swimmerRepository.GetListOfSwimmers(club);
        }
        public bool IsSwimmerFree(int swimmerId)
        {
            return _swimmerRepository.IsSwimmerFree(swimmerId);
        }
        public void UpdateSwimmerSeason(SwimmerSeason swimmerSeason)
        {
            _swimmerRepository.UpdateSwimmerSeason(swimmerSeason);
        }

        public Category GetSwimmerCategory(Swimmer swimmer)
        {
            return _swimmerRepository.GetSwimmerCategory(swimmer);
        }
    }
}