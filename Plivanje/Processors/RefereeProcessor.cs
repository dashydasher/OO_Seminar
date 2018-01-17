using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class RefereeProcessor
    {
        private IRefereeRepository _refereeRepository;

        public IRefereeRepository Repository
        {
            get { return _refereeRepository; }
            set { _refereeRepository = value; }
        }

        public RefereeProcessor()
        {
            _refereeRepository = new RefereeRepository();
        }

        public List<Referee> getReferees()
        {
            return _refereeRepository.getReferees();
        }

        public Referee getReferee(int id)
        {
            return _refereeRepository.getReferee(id);
        }

        public void UpdateReferee(Referee r)
        {
            _refereeRepository.UpdateReferee(r);
        }
    }
}
