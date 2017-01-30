using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GuidantProject.Models
{
    public class UserPoints
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }
    }
}