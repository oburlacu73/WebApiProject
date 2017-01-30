using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuidantProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public string Name { get; set; }
    }
}