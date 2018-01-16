﻿using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWebApp.Models
{
    public class SwimmerViewModel
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public LicenceSwimmer licence { get; set; }
        public string spol { get; set; }
        public bool licenceValid { get; set; }
    }
}