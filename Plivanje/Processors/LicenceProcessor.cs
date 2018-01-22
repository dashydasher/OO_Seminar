using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class LicenceProcessor
    {
        private ILicenceRepository _LicenceRepository;

        public ILicenceRepository Repository
        {
            get { return _LicenceRepository; }
            set { _LicenceRepository = value; }
        }

        public LicenceProcessor()
        {
            _LicenceRepository = new LicenceRepository();
        }

        public bool licenceExists(int licenceNumber)
        {
            return _LicenceRepository.licenceExists(licenceNumber);
        }
    }
}
