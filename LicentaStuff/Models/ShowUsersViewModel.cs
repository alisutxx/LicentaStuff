using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicentaStuff.Models
{
    public class ShowUsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<String> Roles { get; set; }
    }
}