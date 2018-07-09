using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models
{
    public class owl_DynamicPage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowHtml]
        public string Info { get; set; }
       

    }
}