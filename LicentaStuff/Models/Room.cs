using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicentaStuff.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Project Project { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public string Camera { get; set; }
    }
}