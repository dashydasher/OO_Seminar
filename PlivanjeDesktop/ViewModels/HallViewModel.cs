using Plivanje.Models;
using Plivanje.Processors;
using PlivanjeDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlivanjeDesktop.ViewModels
{
    class HallViewModel
    {

        public List<HallModel> allHalls { get; set; }
        Hall myHall;
        HallProcessor hp = new HallProcessor();

        public void LoadHalls()
        {
            allHalls = new List<HallModel>();
            List<Hall> list = new List<Hall>();
            
            list = hp.ListOfhall();
            foreach (var hall in list)
                allHalls.Add(new HallModel
                {
                    Id = hall.Id,
                    Name = hall.Name,
                    Address = hall.Address,
                    Place = hp.getPlace(hall.Id)
                });

        }


        public Hall GetHallByName(string name)
        {
            myHall = hp.getHallByName(name);
            return myHall;
        }
    }
}
