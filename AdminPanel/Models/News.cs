using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models
{
    //[Table ("dd", Schema= "Lookup")]
    public class News
    {
       [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [AllowHtml]
        public string Info { get; set; }

        public string ShortDescription { get; set; }
    }
}