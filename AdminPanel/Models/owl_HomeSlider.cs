using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models
{
    public class owl_HomeSlider
    {
        [Key]
        public int Id { get; set; }
        public string SliderName { get; set; }

        [AllowHtml]
        public string SliderInfo { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}