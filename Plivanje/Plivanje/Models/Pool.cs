﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Plivanje
{
    public class Pool : BaseEntity
    {
        public int Length { get; set; }
        public Hall Hall { get; set; }
    }
}