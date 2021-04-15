using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicentaStuff.Models
{
    public class Project
    {
        public int Id { get; set; }
        public ApplicationUser User { set; get; }
        [Required]
        [MaxLength(128)]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0,20)]
        public int NrRooms { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}