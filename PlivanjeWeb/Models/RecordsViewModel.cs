using Plivanje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlivanjeWeb.Models
{
    public class RecordsViewModel
    {
       public List<RecordViewModel> women { get; set; }
       public  List<RecordViewModel> man { get; set; }
    }
}