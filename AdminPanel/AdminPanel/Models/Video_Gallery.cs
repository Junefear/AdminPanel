using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    public class Video_Gallery
    {
        [Key]
        public int id { get; set; }
        public int Name { get; set; }
        public int Info { get; set; }
        public int Image { get; set; }
    }
}