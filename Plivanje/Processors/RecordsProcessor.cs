using Plivanje.Models;
using Plivanje.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plivanje.Processors
{
    public class RecordsProcessor
    {
        private IRecordsRepository _recordsRepository;

        public IRecordsRepository Repository
        {
            get { return _recordsRepository; }
            set { _recordsRepository = value; }
        }

        public RecordsProcessor()
        {
            _recordsRepository = new RecordsRepository();
        }

        public List<Record> getManRecords()
        {
            return Repository.getMenRecords();
        }


        public List<Record> getWomanRecords()
        {
            return Repository.getWomanRecords();
        }





    }
}


