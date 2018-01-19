using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;
using System.Collections.ObjectModel;

namespace PlivanjeDesktop.ViewModels
{
    class RecordViewModel
    {
        public List<Record> records { get; set; }

        public void LoadRecords(string value)
        {
            records = new List<Record>();
            List<Record> list = new List<Record>();
            var cp = new RecordsProcessor();
            list = value.Equals("MUŠKARCI") ? cp.getManRecords() : cp.getWomanRecords();

            foreach (var record in list)
            {
                
                    records.Add(new Record
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        Category = record.Category,
                        Style = record.Style,
                        Length = record.Length,
                        Place = record.Place,
                        Date = record.Date,
                        RaceTime = record.RaceTime
                    });
                
            }
        }
    }
}
