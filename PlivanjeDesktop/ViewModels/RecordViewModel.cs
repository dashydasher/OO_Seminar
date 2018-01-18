using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;
using System.Collections.ObjectModel;

namespace PlivanjeDesktop.ViewModels
{
    class RecordViewModel
    {
        public List<Record> records { get; set; }
        public void LoadRecords()
        {
            records = new List<Record>();
            List<Record> list = new List<Record>();
            var cp = new RecordsProcessor();
            list = cp.getManRecords();
            foreach (var record in list)
                records.Add(record);
        }
    }
}
