
using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;
using System.Collections.ObjectModel;

namespace PlivanjeDesktop.ViewModels
{
    class RecordViewModel
    {
        public List<Record> records { get; set; }

        public void LoadRecordsByGender(string gender)
        {
            var genderL = gender.Trim().ToLower();
            var rp = new RecordsProcessor();
            records = genderL.Equals("muškarci") ? rp.getManRecords() : rp.getWomanRecords();
        }

    }
}