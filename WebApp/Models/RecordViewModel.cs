﻿using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RecordViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Category { get; set; }
        public string Style { get; set; }
        public int Length { get; set; }
        public string Place { get; set; }
        public  DateTime Date { get; set; }
        public TimeSpan RaceTime { get; set; }
    }
}