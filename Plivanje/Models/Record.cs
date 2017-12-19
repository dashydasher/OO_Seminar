using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Record : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Category { get; set; }
        public string Style { get; set; }
        public int Length { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan RaceTime { get; set; }
    }
}