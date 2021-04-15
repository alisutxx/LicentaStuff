using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicentaStuff.Models
{
    public class ShowProjectViewModel
    {
        public Project Project { get; set; }
        public List<Room> Rooms { get; set; }
    }
}