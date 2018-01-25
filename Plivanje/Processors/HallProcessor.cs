using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class HallProcessor
    {
        private IHallRepository _hallRepository;

        public IHallRepository Repository
        {
            get { return _hallRepository; }
            set { _hallRepository = value; }
        }

        public HallProcessor()
        {
            _hallRepository = new HallRepository();
        }

        public List<Hall> ListOfhall()
        {
            return Repository.getHalls();
        }

        public Hall getHall(int id)
        {
            return _hallRepository.getHall(id);
        }

        public List<Pool> getPools(int id,int len)
        {
            return _hallRepository.getPools(id,len);
        }

        public Place getPlace(int id)
        {
            return _hallRepository.getPlace(id);
        }
        public void UpdateHall(Hall h)
        {
            _hallRepository.UpdateHall(h);
        }
        public List<Hall> getHallsInPlace(int placeId)
        {
            return _hallRepository.getHallsInPlace(placeId);
        }
        public List<Pool> getPools(int idHall)
        {
            return _hallRepository.getPools(idHall);
        }

        public Hall getHallCompetition(int idCompetition)
        {
            return _hallRepository.getHallCompetition(idCompetition);
        }
        public Pool GetPool(int PoolId)
        {
            return _hallRepository.GetPool(PoolId);
        }
    }
}

