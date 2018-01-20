
using Plivanje.Models;
using System.Collections.Generic;
using Plivanje.Processors;
using System.Collections.ObjectModel;

namespace PlivanjeDesktop.ViewModels
{
    class RecordViewModel
    {
        public List<Record> records { get; set; }

        public void LoadRecords(string gender)
        {

            var genderL = gender.Trim().ToLower();
            //  records = new List<Record>();
            //List<Record> list = new List<Record>();
            var rp = new RecordsProcessor();
            records = genderL.Equals("muškarci") ? rp.getManRecords() : rp.getWomanRecords();

            /*foreach (var record in list)
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
                
            }*/
        }



    }
}